using System;
using System.IO;

namespace XpressShare.Core
{
    public static class AppLogger
    {
        private static readonly object SyncRoot = new object();
        private static string _filePath;

        public static void Initialize()
        {
            AppPaths.EnsureApplicationFolders();
            _filePath = Path.Combine(AppPaths.LogPath, "XpressSHARE.log");
            Log("Application startup initialized.");
        }

        public static void Log(string message)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(message);
                lock (SyncRoot)
                {
                    if (!string.IsNullOrEmpty(_filePath))
                    {
                        File.AppendAllText(
                            _filePath,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  " + message + Environment.NewLine);
                    }
                }
            }
            catch { }
        }
    }
}
