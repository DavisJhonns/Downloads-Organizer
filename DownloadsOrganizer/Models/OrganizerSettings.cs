using System;

namespace DownloadsOrganizer
{
    /// <summary>
    /// Represents user-configurable settings for the Downloads Organizer application.
    /// </summary>
    public sealed class OrganizerSettings
    {
        /// <summary>
        /// The root directory path where files will be scanned and organized. Defaults to the user's Downloads folder.
        /// </summary>
        public string RootPath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

        /// <summary>
        /// Determines whether separate folders should be created for each file category.
        /// </summary>
        public bool CreateCategoryFolders { get; set; } = true;

        /// <summary>
        /// Indicates whether existing files should be overwritten when moving files.
        /// </summary>
        public bool OverwriteExisting { get; set; } = false;

        /// <summary>
        /// Enables or disables automatic file system watching for new files.
        /// </summary>
        public bool EnableWatcher { get; set; } = false;

        /// <summary>
        /// Includes subfolders of the root path when scanning for files.
        /// </summary>
        public bool IncludeSubfolders { get; set; } = false;

        /// <summary>
        /// If true, the organizer will simulate actions without actually moving files.
        /// </summary>
        public bool DryRun { get; set; } = true;
    }
}

