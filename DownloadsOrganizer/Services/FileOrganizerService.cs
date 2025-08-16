using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DownloadsOrganizer
{
    /// <summary>
    /// Service responsible for organizing files into categories based on their extensions,
    /// planning and executing moves, undoing operations, and providing real-time file watching.
    /// </summary>
    public sealed class FileOrganizerService : IFileOrganizerService
    {
        private readonly List<CategoryRule> _rules;

        /// <summary>
        /// Initializes a new instance of <see cref="FileOrganizerService"/> with default extension mappings.
        /// </summary>
        public FileOrganizerService()
        {
            _rules = ExtensionMappings.Map
                .Select(kv => new CategoryRule(kv.Key, kv.Value))
                .ToList();
        }

        /// <summary>
        /// Retrieves the default category rules.
        /// </summary>
        /// <returns>A read-only list of <see cref="CategoryRule"/>.</returns>
        public IReadOnlyList<CategoryRule> GetDefaultRules() => _rules;

        /// <summary>
        /// Determines the category of a file based on its extension.
        /// </summary>
        /// <param name="filePath">The full path of the file.</param>
        /// <returns>The matching <see cref="Category"/> or <see cref="Category.Other"/> if no match is found.</returns>
        public Category ResolveCategory(string filePath)
        {
            var ext = Path.GetExtension(filePath)?.TrimStart('.').ToLowerInvariant() ?? string.Empty;
            foreach (var r in _rules)
                if (r.Extensions.Contains(ext))
                    return r.Category;
            return Category.Other;
        }

        /// <summary>
        /// Computes the target path for a file based on its category and folder structure.
        /// </summary>
        /// <param name="filePath">The source file path.</param>
        /// <param name="rootPath">The root directory to organize into.</param>
        /// <param name="createCategoryFolders">Whether to create category and extension folders.</param>
        /// <returns>The full target path for the file.</returns>
        public string GetTargetPath(string filePath, string rootPath, bool createCategoryFolders)
        {
            var fileName = Path.GetFileName(filePath);
            var category = ResolveCategory(filePath);

            var targetDir = rootPath;
            if (createCategoryFolders)
            {
                targetDir = Path.Combine(targetDir, category.ToString());
                Directory.CreateDirectory(targetDir);

                var extFolder = Path.GetExtension(filePath)?.TrimStart('.').ToLowerInvariant() ?? "other";
                targetDir = Path.Combine(targetDir, extFolder);
                Directory.CreateDirectory(targetDir);
            }

            return Path.Combine(targetDir, fileName);
        }

        /// <summary>
        /// Generates a plan of source and target paths for files that need to be moved.
        /// </summary>
        /// <param name="rootPath">Root directory to scan.</param>
        /// <param name="includeSubfolders">Whether to include subfolders.</param>
        /// <param name="createCategoryFolders">Whether to create category and extension subfolders.</param>
        /// <returns>An enumerable of tuples with source and target file paths.</returns>
        public IEnumerable<(string Source, string Target)> PlanMoves(string rootPath, bool includeSubfolders, bool createCategoryFolders)
        {
            if (!Directory.Exists(rootPath)) yield break;

            var opt = includeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var files = Directory.EnumerateFiles(rootPath, "*.*", opt)
                                  .Where(p => !IsInCategoryFolder(rootPath, p));

            foreach (var src in files)
            {
                var target = GetTargetPath(src, rootPath, createCategoryFolders);
                if (!string.Equals(src, target, StringComparison.OrdinalIgnoreCase))
                    yield return (src, target);
            }
        }

        private static bool IsInCategoryFolder(string root, string path)
        {
            var dir = Path.GetDirectoryName(path) ?? string.Empty;
            foreach (var cat in Enum.GetNames(typeof(Category)))
            {
                var catDir = Path.Combine(root, cat);
                if (dir.StartsWith(catDir, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Executes file moves and optionally overwrites existing files.
        /// </summary>
        /// <param name="moves">List of source and target file paths.</param>
        /// <param name="overwrite">Whether to overwrite existing files at the target location.</param>
        /// <param name="applied">Outputs the list of successfully applied moves.</param>
        public void ExecuteMoves(IEnumerable<(string Source, string Target)> moves, bool overwrite, out List<(string From, string To)> applied)
        {
            applied = new List<(string From, string To)>();
            foreach (var (src, tgt) in moves)
            {
                var targetDir = Path.GetDirectoryName(tgt);
                if (!string.IsNullOrWhiteSpace(targetDir) && !Directory.Exists(targetDir))
                    Directory.CreateDirectory(targetDir);

                var finalTarget = overwrite ? tgt : GetNonClashingPath(tgt);
                File.Move(src, finalTarget);
                applied.Add((src, finalTarget));
            }
        }

        /// <summary>
        /// Generates a unique file path by appending a numeric suffix if the file already exists.
        /// </summary>
        /// <param name="path">The original file path.</param>
        /// <returns>A non-conflicting file path with a numeric suffix if necessary.</returns>
        private static string GetNonClashingPath(string path)
        {
            if (!File.Exists(path)) return path;

            var dir = Path.GetDirectoryName(path) ?? string.Empty;
            var name = Path.GetFileNameWithoutExtension(path);
            var ext = Path.GetExtension(path);
            int i = 1;
            string candidate;

            do
            {
                candidate = Path.Combine(dir, $"{name} ({i++}){ext}");
            } while (File.Exists(candidate));

            return candidate;
        }

        /// <summary>
        /// Undoes previously executed file moves.
        /// </summary>
        /// <param name="applied">List of applied moves to revert.</param>
        public void UndoMoves(IEnumerable<(string From, string To)> applied)
        {
            foreach (var (from, to) in applied.Reverse())
            {
                try
                {
                    var originalDir = Path.GetDirectoryName(from);
                    if (!string.IsNullOrWhiteSpace(originalDir) && !Directory.Exists(originalDir))
                        Directory.CreateDirectory(originalDir);
                    if (File.Exists(to) && !File.Exists(from))
                        File.Move(to, from);
                }
                catch { }
            }
        }

        /// <summary>
        /// Creates a <see cref="FileSystemWatcher"/> to automatically detect new files and invoke a callback.
        /// </summary>
        /// <param name="rootPath">Root directory to watch.</param>
        /// <param name="includeSubfolders">Whether to watch subdirectories.</param>
        /// <param name="onNewFile">Callback invoked when a new file is detected.</param>
        /// <returns>The configured <see cref="FileSystemWatcher"/> instance.</returns>
        public FileSystemWatcher CreateWatcher(string rootPath, bool includeSubfolders, Action<string> onNewFile)
        {
            var w = new FileSystemWatcher(rootPath)
            {
                IncludeSubdirectories = includeSubfolders,
                Filter = "*.*",
                EnableRaisingEvents = true,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.Size
            };
            FileSystemEventHandler handler = (s, e) =>
            {
                if (e.ChangeType == WatcherChangeTypes.Created)
                {
                    System.Threading.Tasks.Task.Run(async () =>
                    {
                        await System.Threading.Tasks.Task.Delay(500);
                        onNewFile?.Invoke(e.FullPath);
                    });
                }
            };
            w.Created += handler;
            return w;
        }
    }
}
