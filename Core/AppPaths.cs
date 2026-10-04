using System;
using System.IO;

namespace XpressShare.Core
{
    public static class AppPaths
    {
        private static string _basePath;

        public static string BasePath
        {
            get
            {
                if (string.IsNullOrEmpty(_basePath))
                {
                    string local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    _basePath = Path.Combine(local, "XpressSHARE");
                    try
                    {
                        if (!Directory.Exists(_basePath)) Directory.CreateDirectory(_basePath);
                    }
                    catch
                    {
                        // ignore in skeleton
                    }
                }
                return _basePath;
            }
        }

        public static string DataPath
        {
            get { return Path.Combine(BasePath, "Data"); }
        }

        public static string LogPath
        {
            get { return Path.Combine(BasePath, "Logs"); }
        }

        public static string ReceivedFilesPath
        {
            get { return Path.Combine(BasePath, "Received Files"); }
        }

        public static void EnsureApplicationFolders()
        {
            Directory.CreateDirectory(BasePath);
            Directory.CreateDirectory(DataPath);
            Directory.CreateDirectory(LogPath);
            Directory.CreateDirectory(ReceivedFilesPath);
        }
    }
}
