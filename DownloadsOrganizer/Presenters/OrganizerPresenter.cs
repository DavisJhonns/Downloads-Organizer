using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DownloadsOrganizer
{
    /// <summary>
    /// Implements the main presenter logic for the Downloads Organizer using the MVP pattern.
    /// Handles scanning, executing file moves, watching folders, undoing moves, and updating the view.
    /// </summary>
    public sealed class OrganizerPresenter : IOrganizerPresenter
    {
        private readonly IMainView _view;
        private readonly IFileOrganizerService _service;
        private FileSystemWatcher _watcher;
        private List<(string Source, string Target)> _currentPlan = new List<(string Source, string Target)>();
        private List<(string From, string To)> _lastApplied = new List<(string From, string To)>();

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizerPresenter"/> class with the specified view and service.
        /// </summary>
        /// <param name="view">The view interface for interacting with UI elements.</param>
        /// <param name="service">The service responsible for planning and executing file moves.</param>
        public OrganizerPresenter(IMainView view, IFileOrganizerService service)
        {
            _view = view;
            _service = service;

            _view.OnScan += Scan;
            _view.OnExecute += Execute;
            _view.OnWatcherToggled += ToggleWatcher;
            _view.OnUndo += UndoLast;
            _view.OnOpenRoot += OpenRoot;
            _view.OnBrowseRoot += BrowseRoot;
            _view.OnSettingsChanged += ApplySettings;
        }

        /// <summary>
        /// Initializes the presenter and updates the view status and buttons.
        /// </summary>
        public void Initialize()
        {
            _view.SetStatus("Ready");
            _view.AppendLog("Initialized.");
            _view.SetButtonsEnabled(canScan: true, canExecute: false, canUndo: _lastApplied.Any());
        }

        /// <summary>
        /// Scans the root directory (and optionally subdirectories) and prepares a plan for moving files.
        /// </summary>
        public void Scan()
        {
            var s = _view.Settings;
            _view.AppendLog($"Scanning {s.RootPath}...");
            _currentPlan = _service.PlanMoves(s.RootPath, s.IncludeSubfolders, s.CreateCategoryFolders).ToList();
            _view.ShowPlan(_currentPlan);
            _view.SetButtonsEnabled(canScan: true, canExecute: _currentPlan.Any(), canUndo: _lastApplied.Any());
            _view.SetStatus($"Found {_currentPlan.Count} move(s).");
        }

        /// <summary>
        /// Executes the planned file moves, respecting the dry run and overwrite settings.
        /// </summary>
        public void Execute()
        {
            var s = _view.Settings;
            if (s.DryRun)
            {
                _view.AppendLog("Dry Run is ON – no files moved. Toggle it off to execute.");
                return;
            }

            _view.AppendLog("Executing moves...");
            _service.ExecuteMoves(_currentPlan, s.OverwriteExisting, out _lastApplied);
            _view.AppendLog($"Moved {_lastApplied.Count} file(s).");
            _currentPlan.Clear();
            _view.ShowPlan(_currentPlan);
            _view.SetButtonsEnabled(canScan: true, canExecute: false, canUndo: _lastApplied.Any());
            _view.SetStatus("Done");
        }

        /// <summary>
        /// Enables or disables the file system watcher for automatic file organization.
        /// </summary>
        /// <param name="enable">True to enable the watcher; false to disable it.</param>
        public void ToggleWatcher(bool enable)
        {
            var s = _view.Settings;
            if (enable && _watcher == null)
            {
                _watcher = _service.CreateWatcher(s.RootPath, s.IncludeSubfolders, OnNewFileDetected);
                _view.AppendLog("Watcher enabled.");
                _view.SetWatcherState(true);
            }
            else if (!enable && _watcher != null)
            {
                _watcher.EnableRaisingEvents = false;
                _watcher.Dispose();
                _watcher = null;
                _view.AppendLog("Watcher disabled.");
                _view.SetWatcherState(false);
            }
        }

        /// <summary>
        /// Callback for the file watcher when a new file is detected.
        /// Moves the file automatically if DryRun is off.
        /// </summary>
        /// <param name="path">The path of the newly detected file.</param>
        private void OnNewFileDetected(string path)
        {
            try
            {
                if (!File.Exists(path)) return;
                var s = _view.Settings;
                var target = _service.GetTargetPath(path, s.RootPath, s.CreateCategoryFolders);
                if (!s.DryRun)
                {
                    _service.ExecuteMoves(new[] { (path, target) }, s.OverwriteExisting, out var applied);
                    _lastApplied = applied;
                    _view.AppendLog($"Auto-moved: {Path.GetFileName(path)} -> {Path.GetDirectoryName(target)}");
                    _view.SetButtonsEnabled(canScan: true, canExecute: false, canUndo: _lastApplied.Any());
                }
                else
                {
                    _view.AppendLog($"[DryRun] Would auto-move: {Path.GetFileName(path)} -> {Path.GetDirectoryName(target)}");
                }
            }
            catch (Exception ex)
            {
                _view.AppendLog($"Watcher error: {ex.Message}");
            }
        }

        /// <summary>
        /// Undoes the last executed file moves.
        /// </summary>
        public void UndoLast()
        {
            if (_lastApplied.Count == 0)
            {
                _view.AppendLog("Nothing to undo.");
                return;
            }
            _service.UndoMoves(_lastApplied);
            _view.AppendLog($"Undo moved {_lastApplied.Count} file(s).");
            _lastApplied.Clear();
            _view.SetButtonsEnabled(canScan: true, canExecute: _currentPlan.Any(), canUndo: false);
        }

        /// <summary>
        /// Opens the root directory in the system file explorer.
        /// </summary>
        public void OpenRoot()
        {
            var s = _view.Settings;
            if (Directory.Exists(s.RootPath))
                Process.Start(new ProcessStartInfo { FileName = s.RootPath, UseShellExecute = true });
        }

        /// <summary>
        /// Opens a folder browser dialog to allow the user to select a new root directory.
        /// </summary>
        public void BrowseRoot()
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = "Válaszd ki a Letöltések mappát";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var s = _view.Settings;
                s.RootPath = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// Applies new organizer settings and logs the update.
        /// </summary>
        /// <param name="settings">The updated settings object.</param>
        public void ApplySettings(OrganizerSettings settings)
        {
            _view.AppendLog("Settings updated.");
        }
    }
}
