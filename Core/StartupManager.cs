using System;
using XpressShare.Models;
using XpressShare.Services;

namespace XpressShare.Core
{
    public static class StartupManager
    {
        private static LocalAccountService _localAccountService;

        public static void Initialize()
        {
            Initialize((Action<int, string>)null);
        }

        public static void Initialize(Action<string> reportStatus)
        {
            Initialize(delegate(int percent, string message)
            {
                if (reportStatus != null)
                {
                    reportStatus(message);
                }
            });
        }

        public static void Initialize(Action<int, string> reportProgress)
        {
            Report(reportProgress, 5, "Preparing local application folders...");
            AppPaths.EnsureApplicationFolders();

            Report(reportProgress, 20, "Starting the XpressSHARE activity log...");
            AppLogger.Initialize();

            Report(reportProgress, 40, "Loading local application settings...");
            AppSettings settings = AppSettings.Instance;
            ConfigurationService configurationService = new ConfigurationService();
            configurationService.Load();

            Report(reportProgress, 60, "Creating the local configuration service...");
            ServiceRegistry.Register("ConfigurationService", configurationService);

            Report(reportProgress, 75, "Loading this computer's device identity...");
            DeviceIdentityService identityService = new DeviceIdentityService();
            DeviceIdentity identity = identityService.GetIdentity();

            ServiceRegistry.Register("DeviceIdentityService", identityService);
            ServiceRegistry.Register("DeviceIdentity", identity);

            Report(reportProgress, 88, "Preparing local account and trusted-device services...");
            _localAccountService = new LocalAccountService();
            EnsureDefaultDevAccount();
            ServiceRegistry.Register("LocalAccountService", _localAccountService);
            ServiceRegistry.Register("TrustedDeviceService", new TrustedDeviceService());

            AppLogger.Log("Device identity ready: " + identity.DeviceId);
            Report(reportProgress, 100, "Startup initialization complete.");
        }

        public static bool IsFirstLaunch()
        {
            return !AppSettings.Instance.FirstLaunchDone;
        }

        public static void MarkFirstLaunchComplete()
        {
            AppSettings.Instance.FirstLaunchDone = true;
            AppSettings.Instance.Save();
        }

        public static bool AnyUserAccountExists()
        {
            if (_localAccountService == null)
                _localAccountService = new LocalAccountService();

            Storage.UserRepository repo = new Storage.UserRepository();
            System.Collections.Generic.List<Models.UserAccount> users = repo.LoadAll();
            return users.Count > 0;
        }

        private static void EnsureDefaultDevAccount()
        {
            try
            {
                if (!AnyUserAccountExists())
                {
                    _localAccountService.Register("xpr01", "Developer", "devxpr11");
                    AppLogger.Log("Default dev account seeded: xpr01");
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("EnsureDefaultDevAccount error: " + ex.Message);
            }
        }

        private static void Report(Action<int, string> reportProgress, int percent, string message)
        {
            if (reportProgress != null)
            {
                reportProgress(percent, message);
            }
        }
    }
}
