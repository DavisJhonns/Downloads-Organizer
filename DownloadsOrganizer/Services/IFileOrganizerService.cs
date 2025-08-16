using System;
using System.Collections.Generic;
using System.IO;

namespace DownloadsOrganizer
{
    /// <summary>
    /// Defines operations for organizing files, including categorization, moving, undoing, and file watching.
    /// </summary>
    public interface IFileOrganizerService
    {
        /// <summary>
        /// Gets the default set of category rules used for organizing files.
        /// </summary>
        /// <returns>A read-only list of <see cref="CategoryRule"/>.</returns>
        IReadOnlyList<CategoryRule> GetDefaultRules();

        /// <summary>
        /// Determines the category of a file based on its extension.
        /// </summary>
        /// <param name="filePath">Full path of the file.</param>
        /// <returns>The <see cref="Category"/> corresponding to the file's extension, or <see cref="Category.Other"/> if no match is found.</returns>
        Category ResolveCategory(string filePath);

        /// <summary>
        /// Computes the target path for a file, optionally creating category and extension folders.
        /// </summary>
        /// <param name="filePath">The source file path.</param>
        /// <param name="rootPath">The root directory for organized files.</param>
        /// <param name="createCategoryFolders">Whether to create category and extension subfolders.</param>
        /// <returns>The computed target path for the file.</returns>
        string GetTargetPath(string filePath, string rootPath, bool createCategoryFolders);

        /// <summary>
        /// Plans the moves of files from the root directory to their organized destinations.
        /// </summary>
        /// <param name="rootPath">The root directory to scan.</param>
        /// <param name="includeSubfolders">Whether to include subdirectories.</param>
        /// <param name="createCategoryFolders">Whether to create category and extension folders for organized files.</param>
        /// <returns>An enumerable of tuples containing source and target file paths.</returns>
        IEnumerable<(string Source, string Target)> PlanMoves(string rootPath, bool includeSubfolders, bool createCategoryFolders);

        /// <summary>
        /// Executes the planned file moves, optionally overwriting existing files.
        /// </summary>
        /// <param name="moves">List of source and target file path tuples.</param>
        /// <param name="overwrite">If true, existing files at the target location will be overwritten.</param>
        /// <param name="applied">Outputs the list of moves that were successfully applied.</param>
        void ExecuteMoves(IEnumerable<(string Source, string Target)> moves, bool overwrite, out List<(string From, string To)> applied);

        /// <summary>
        /// Reverts previously executed file moves.
        /// </summary>
        /// <param name="applied">List of applied moves to undo.</param>
        void UndoMoves(IEnumerable<(string From, string To)> applied);

        /// <summary>
        /// Creates a <see cref="FileSystemWatcher"/> to monitor new files and trigger a callback.
        /// </summary>
        /// <param name="rootPath">The directory to watch.</param>
        /// <param name="includeSubfolders">Whether to watch subdirectories as well.</param>
        /// <param name="onNewFile">Callback invoked when a new file is detected.</param>
        /// <returns>The configured <see cref="FileSystemWatcher"/>.</returns>
        FileSystemWatcher CreateWatcher(string rootPath, bool includeSubfolders, Action<string> onNewFile);
    }
}