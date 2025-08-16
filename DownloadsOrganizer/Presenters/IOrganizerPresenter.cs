using System.Collections.Generic;

namespace DownloadsOrganizer
{
    /// <summary>
    /// Defines the presenter interface in the MVP pattern for the Downloads Organizer.
    /// Responsible for handling user actions and coordinating between the view and the service.
    /// </summary>
    public interface IOrganizerPresenter
    {
        /// <summary>
        /// Initializes the presenter and sets up necessary state or subscriptions.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Scans the root directory for files and categorizes them according to rules.
        /// </summary>
        void Scan();

        /// <summary>
        /// Executes the planned file moves according to the organizer rules.
        /// </summary>
        void Execute();

        /// <summary>
        /// Enables or disables the file system watcher for automatic monitoring of new files.
        /// </summary>
        /// <param name="enable">True to enable the watcher, false to disable.</param>
        void ToggleWatcher(bool enable);

        /// <summary>
        /// Undoes the last batch of file moves.
        /// </summary>
        void UndoLast();

        /// <summary>
        /// Opens the root folder in the system file explorer.
        /// </summary>
        void OpenRoot();

        /// <summary>
        /// Opens a dialog to browse and select the root folder for organizing.
        /// </summary>
        void BrowseRoot();

        /// <summary>
        /// Applies user-configurable settings to the presenter and underlying service.
        /// </summary>
        /// <param name="settings">The settings to apply.</param>
        void ApplySettings(OrganizerSettings settings);
    }
}
