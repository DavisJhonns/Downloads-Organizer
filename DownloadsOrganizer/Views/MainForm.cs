using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DownloadsOrganizer
{
    /// <summary>
    /// Represents the main form of the Downloads Organizer application, implementing the <see cref="IMainView"/> interface.
    /// Handles UI interactions, propagates changes to the presenter, and updates controls based on user actions.
    /// </summary>
    public partial class MainForm : Form, IMainView
    {
        // Events exposed to the presenter
        public event Action OnScan;
        public event Action OnExecute;
        public event Action<bool> OnWatcherToggled;
        public event Action OnUndo;
        public event Action OnOpenRoot;
        public event Action OnBrowseRoot;
        public event Action<OrganizerSettings> OnSettingsChanged;

        /// <summary>
        /// Gets the current organizer settings.
        /// </summary>
        public OrganizerSettings Settings { get; private set; } = new OrganizerSettings();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// Sets up UI components, associates events, and applies default settings.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            AssociateViewEvents();
            AssociateChangePropagates();

            DefaultSettings();

            txtRoot.Text = Settings.RootPath;

            // Notify presenter we're ready
            Load += (s, e) => { };
        }

        /// <summary>
        /// Associates UI control events with corresponding actions for the presenter.
        /// </summary>
        private void AssociateViewEvents()
        {
            btnScan.Click += (s, e) => OnScan?.Invoke();
            btnExecute.Click += (s, e) => OnExecute?.Invoke();
            btnUndo.Click += (s, e) => OnUndo?.Invoke();
            btnOpenRoot.Click += (s, e) => OnOpenRoot?.Invoke();
            btnBrowse.Click += (s, e) => { OnBrowseRoot?.Invoke(); SyncFromSettingsToUI(); };
            chkWatcher.CheckedChanged += (s, e) => OnWatcherToggled?.Invoke(chkWatcher.Checked);
        }

        /// <summary>
        /// Propagates UI control changes to the <see cref="Settings"/> object and notifies the presenter.
        /// </summary>
        private void AssociateChangePropagates()
        {
            void propagate() { UpdateSettingsFromUI(); OnSettingsChanged?.Invoke(Settings); }
            txtRoot.TextChanged += (s, e) => propagate();
            chkCreateFolders.CheckedChanged += (s, e) => propagate();
            chkOverwrite.CheckedChanged += (s, e) => propagate();
            chkIncludeSub.CheckedChanged += (s, e) => propagate();
            chkDryRun.CheckedChanged += (s, e) => propagate();
        }

        /// <summary>
        /// Applies default settings to the form controls.
        /// </summary>
        private void DefaultSettings()
        {
            txtRoot.Text = Settings.RootPath;
            chkCreateFolders.Checked = true;
            chkDryRun.Checked = true;
        }

        /// <summary>
        /// Synchronizes the UI controls with the current <see cref="Settings"/> values.
        /// </summary>
        private void SyncFromSettingsToUI()
        {
            txtRoot.Text = Settings.RootPath;
            chkCreateFolders.Checked = Settings.CreateCategoryFolders;
            chkOverwrite.Checked = Settings.OverwriteExisting;
            chkIncludeSub.Checked = Settings.IncludeSubfolders;
            chkDryRun.Checked = Settings.DryRun;
            chkWatcher.Checked = Settings.EnableWatcher;
        }

        /// <summary>
        /// Updates the <see cref="Settings"/> object based on the current state of the UI controls.
        /// </summary>
        private void UpdateSettingsFromUI()
        {
            Settings.RootPath = txtRoot.Text;
            Settings.CreateCategoryFolders = chkCreateFolders.Checked;
            Settings.OverwriteExisting = chkOverwrite.Checked;
            Settings.IncludeSubfolders = chkIncludeSub.Checked;
            Settings.DryRun = chkDryRun.Checked;
            Settings.EnableWatcher = chkWatcher.Checked;
        }

        #region IMainView Implementation

        public void ShowPlan(IEnumerable<(string Source, string Target)> plan)
        {
            grid.DataSource = plan.Select(x => new { x.Source, x.Target }).ToList();
        }
        public void AppendLog(string message)
        {
            log.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
        }
        public void SetStatus(string text) => statusText.Text = text;
        public void SetWatcherState(bool enabled) => chkWatcher.Checked = enabled;
        public void SetButtonsEnabled(bool canScan, bool canExecute, bool canUndo)
        {
            btnScan.Enabled = canScan;
            btnExecute.Enabled = canExecute;
            btnUndo.Enabled = canUndo;
        }

        #endregion
    }
}
