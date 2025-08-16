using System.Collections.Generic;

namespace DownloadsOrganizer
{
    /// <summary>
    /// Internal mappings from categories to default file extensions.
    /// </summary>
    internal static class ExtensionMappings
    {
        internal static readonly Dictionary<Category, string[]> Map = new Dictionary<Category, string[]>()
        {
            [Category.Documents] = new[] { "pdf", "doc", "docx", "odt", "rtf", "txt", "md", "xls", "xlsx", "ods", "ppt", "pptx", "odp", "csv", "tsv", "epub", "mobi" },
            [Category.Images] = new[] { "jpg", "jpeg", "png", "gif", "bmp", "tif", "tiff", "webp", "heic", "heif", "svg", "ico", "raw", "cr2", "nef", "arw" },
            [Category.Videos] = new[] { "mp4", "avi", "mkv", "mov", "wmv", "flv", "mpeg", "mpg", "webm", "3gp", "mts", "ts" },
            [Category.Audio] = new[] { "mp3", "wav", "flac", "aac", "ogg", "oga", "wma", "m4a", "opus", "aiff", "mid", "midi" },
            [Category.Executables] = new[] { "exe", "msi", "apk", "ipa", "bat", "cmd", "ps1", "dmg", "pkg", "appimage", "deb", "rpm", "sh" },
            [Category.Archives] = new[] { "zip", "rar", "7z", "tar", "gz", "bz2", "xz", "tgz", "iso", "img" },
            [Category.Code] = new[] { "c", "cpp", "cs", "java", "py", "js", "ts", "php", "html", "css", "xml", "json", "yaml", "yml", "sql", "db", "db3", "sqlite", "sln", "csproj" }
        };
    }
}
