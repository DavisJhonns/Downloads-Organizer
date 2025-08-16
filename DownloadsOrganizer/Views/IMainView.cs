using System;
using System.Collections.Generic;

namespace DownloadsOrganizer
{
    /// <summary>
    /// Represents the main view interface for the Downloads Organizer application.
    /// Provides methods to display plans, log messages, update status, control watcher and buttons, and exposes events for user interactions.
    /// </summary>
    public interface IMainView
    {
        /// <summary>
        /// Gets the current organizer settings.
        /// </summary>
        OrganizerSettings Settings { get; }

        /// <summary>
        /// Displays the planned file moves to the user.
        /// </summary>
        /// <param name="plan">Enumerable of tuples containing source and target file paths.</param>
        void ShowPlan(IEnumerable<(string Source, string Target)> plan);

        /// <summary>
        /// Appends a message to the application's log.
        /// </summary>
        /// <param name="message">The message to append.</param>
        void AppendLog(string message);

        /// <summary>
        /// Updates the status text in the UI.
        /// </summary>
        /// <param name="text">The status text to display.</param>
        void SetStatus(string text);

        /// <summary>
        /// Updates the UI to reflect the enabled state of the file watcher.
        /// </summary>
        /// <param name="enabled">True if the watcher is enabled; otherwise, false.</param>
        void SetWatcherState(bool enabled);

        /// <summary>
        /// Enables or disables action buttons based on the current state.
        /// </summary>
        /// <param name="canScan">Enable the scan button if true.</param>
        /// <param name="canExecute">Enable the execute button if true.</param>
        /// <param name="canUndo">Enable the undo button if true.</param>
        void SetButtonsEnabled(bool canScan, bool canExecute, bool canUndo);

        /// <summary>
        /// Event triggered when the user initiates a scan.
        /// </summary>
        event Action OnScan;

        /// <summary>
        /// Event triggered when the user initiates executing planned moves.
        /// </summary>
        event Action OnExecute;

        /// <summary>
        /// Event triggered when the file watcher is toggled on or off.
        /// </summary>
        event Action<bool> OnWatcherToggled;

        /// <summary>
        /// Event triggered when the user wants to undo previous moves.
        /// </summary>
        event Action OnUndo;

        /// <summary>
        /// Event triggered when the user wants to open the root directory.
        /// </summary>
        event Action OnOpenRoot;

        /// <summary>
        /// Event triggered when the user wants to browse for a new root directory.
        /// </summary>
        event Action OnBrowseRoot;

        /// <summary>
        /// Event triggered when the organizer settings are changed.
        /// </summary>
        event Action<OrganizerSettings> OnSettingsChanged;
    }
}
