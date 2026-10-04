using System;
using System.IO;
using System.Text;

namespace XpressShare.Core
{
    public sealed class AppSettings
    {
        private static AppSettings _instance;
        private string _settingsFilePath;
        private readonly object _lockObj = new object();

        public static AppSettings Instance
        {
            get { return _instance ?? (_instance = new AppSettings()); }
        }

        private AppSettings()
        {
            ApplicationId = "XpressSHARE";
            _settingsFilePath = Path.Combine(AppPaths.BasePath, "settings.conf");

            FirstLaunchDone = false;
            TrayMinimizePreference = false;
            ReceiveEnabled = true;
            AutoRetry = false;
            AutoAcceptTransfers = false;
            string userProfile = Environment.GetEnvironmentVariable("USERPROFILE");
            string defaultDownloads = !string.IsNullOrEmpty(userProfile) ? Path.Combine(userProfile, "Downloads") : Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            SelectedDownloadFolder = defaultDownloads;
            CurrentUsername = string.Empty;
            DevicePort = 15000;
            TransferPort = 15001;
            DarkMode = false;
            RememberMe = false;
            AuthSessionToken = string.Empty;
            PreferredInterface = "Auto";
            AutoOptimizeTransfers = true;

            Load();
        }

        public string ApplicationId { get; private set; }
        public bool FirstLaunchDone { get; set; }
        public bool TrayMinimizePreference { get; set; }
        public bool ReceiveEnabled { get; set; }
        public bool AutoRetry { get; set; }
        public bool AutoAcceptTransfers { get; set; }
        public string SelectedDownloadFolder { get; set; }
        public string CurrentUsername { get; set; }
        public int DevicePort { get; set; }
        public int TransferPort { get; set; }
        public bool DarkMode { get; set; }
        public bool RememberMe { get; set; }
        public string AuthSessionToken { get; set; }
        public string PreferredInterface { get; set; }
        public bool AutoOptimizeTransfers { get; set; }

        public void Save()
        {
            lock (_lockObj)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("FirstLaunchDone=" + FirstLaunchDone);
                    sb.AppendLine("TrayMinimizePreference=" + TrayMinimizePreference);
                    sb.AppendLine("ReceiveEnabled=" + ReceiveEnabled);
                    sb.AppendLine("AutoRetry=" + AutoRetry);
                    sb.AppendLine("AutoAcceptTransfers=" + AutoAcceptTransfers);
                    sb.AppendLine("SelectedDownloadFolder=" + EscapeValue(SelectedDownloadFolder));
                    sb.AppendLine("CurrentUsername=" + EscapeValue(CurrentUsername));
                    sb.AppendLine("DevicePort=" + DevicePort);
                    sb.AppendLine("TransferPort=" + TransferPort);
                    sb.AppendLine("DarkMode=" + DarkMode);
                    sb.AppendLine("RememberMe=" + RememberMe);
                    sb.AppendLine("AuthSessionToken=" + EscapeValue(AuthSessionToken));
                    sb.AppendLine("PreferredInterface=" + EscapeValue(PreferredInterface));
                    sb.AppendLine("AutoOptimizeTransfers=" + AutoOptimizeTransfers);

                    File.WriteAllText(_settingsFilePath, sb.ToString(), Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("AppSettings.Save error: " + ex.Message);
                }
            }
        }

        private void Load()
        {
            lock (_lockObj)
            {
                if (!File.Exists(_settingsFilePath))
                    return;

                try
                {
                    string content = File.ReadAllText(_settingsFilePath, Encoding.UTF8);
                    string[] lines = content.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line) || line.Trim().Length == 0 || line.StartsWith("#"))
                            continue;

                        int eqIdx = line.IndexOf('=');
                        if (eqIdx <= 0)
                            continue;

                        string key = line.Substring(0, eqIdx).Trim();
                        string value = line.Substring(eqIdx + 1).Trim();

                        switch (key)
                        {
                            case "FirstLaunchDone":
                                bool flc;
                                if (bool.TryParse(value, out flc))
                                    FirstLaunchDone = flc;
                                break;
                            case "TrayMinimizePreference":
                                bool tmp;
                                if (bool.TryParse(value, out tmp))
                                    TrayMinimizePreference = tmp;
                                break;
                            case "ReceiveEnabled":
                                bool re;
                                if (bool.TryParse(value, out re))
                                    ReceiveEnabled = re;
                                break;
                            case "AutoRetry":
                                bool ar;
                                if (bool.TryParse(value, out ar))
                                    AutoRetry = ar;
                                break;
                            case "AutoAcceptTransfers":
                                bool aat;
                                if (bool.TryParse(value, out aat))
                                    AutoAcceptTransfers = aat;
                                break;
                            case "SelectedDownloadFolder":
                                SelectedDownloadFolder = UnescapeValue(value);
                                break;
                            case "CurrentUsername":
                                CurrentUsername = UnescapeValue(value);
                                break;
                            case "DevicePort":
                                int dp;
                                if (int.TryParse(value, out dp))
                                    DevicePort = dp > 0 ? dp : 15000;
                                break;
                            case "TransferPort":
                                int tp;
                                if (int.TryParse(value, out tp))
                                    TransferPort = tp > 0 ? tp : 15001;
                                break;
                            case "DarkMode":
                                bool dm;
                                if (bool.TryParse(value, out dm))
                                    DarkMode = dm;
                                break;
                            case "RememberMe":
                                bool rm;
                                if (bool.TryParse(value, out rm))
                                    RememberMe = rm;
                                break;
                            case "AuthSessionToken":
                                AuthSessionToken = UnescapeValue(value);
                                break;
                            case "PreferredInterface":
                                PreferredInterface = UnescapeValue(value);
                                break;
                            case "AutoOptimizeTransfers":
                                bool aot;
                                if (bool.TryParse(value, out aot))
                                    AutoOptimizeTransfers = aot;
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.Log("AppSettings.Load error: " + ex.Message);
                }
            }
        }

        private string EscapeValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            return value.Replace("\\", "\\\\").Replace("\n", "\\n").Replace("\r", "\\r");
        }

        private string UnescapeValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            return value.Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\\\", "\\");
        }
    }
}
