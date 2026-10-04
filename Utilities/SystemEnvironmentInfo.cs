using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace XpressShare.Utilities
{
    /// <summary>
    /// Operating system, architecture, and runtime detection helper for .NET 3.5.
    /// Safely identifies Windows XP through Windows 11 without requiring modern manifests.
    /// </summary>
    public static class SystemEnvironmentInfo
    {
        private static string _osFriendlyName;
        private static string _osBuildNumber;
        private static string _osArchitecture;
        private static string _processArchitecture;
        private static string _appVersion;

        public static string ProcessArchitecture
        {
            get
            {
                if (_processArchitecture == null)
                {
                    _processArchitecture = (IntPtr.Size == 8) ? "64-bit" : "32-bit";
                }
                return _processArchitecture;
            }
        }

        public static string OsArchitecture
        {
            get
            {
                if (_osArchitecture == null)
                {
                    _osArchitecture = Is64BitOperatingSystem() ? "64-bit" : "32-bit";
                }
                return _osArchitecture;
            }
        }

        public static string OperatingSystemFriendlyName
        {
            get
            {
                if (_osFriendlyName == null)
                {
                    DetectOperatingSystem();
                }
                return _osFriendlyName;
            }
        }

        public static string BuildNumber
        {
            get
            {
                if (_osBuildNumber == null)
                {
                    DetectOperatingSystem();
                }
                return _osBuildNumber;
            }
        }

        public static string AppVersion
        {
            get
            {
                if (_appVersion == null)
                {
                    try
                    {
                        Version v = Assembly.GetExecutingAssembly().GetName().Version;
                        _appVersion = string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
                    }
                    catch
                    {
                        _appVersion = "0.5.0";
                    }
                }
                return _appVersion;
            }
        }

        public static bool Is64BitOperatingSystem()
        {
            if (IntPtr.Size == 8) return true; // 64-bit process can only run on 64-bit OS

            try
            {
                string arch64 = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432");
                if (!string.IsNullOrEmpty(arch64)) return true;

                string arch = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
                if (string.Equals(arch, "AMD64", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(arch, "IA64", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(arch, "ARM64", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            catch { }

            return false;
        }

        private static void DetectOperatingSystem()
        {
            string prodName = string.Empty;
            string buildNum = string.Empty;
            string displayVer = string.Empty;
            string csdVer = string.Empty;

            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    if (key != null)
                    {
                        object objProd = key.GetValue("ProductName");
                        if (objProd != null) prodName = objProd.ToString();

                        object objBuild = key.GetValue("CurrentBuild");
                        if (objBuild == null) objBuild = key.GetValue("CurrentBuildNumber");
                        if (objBuild != null) buildNum = objBuild.ToString();

                        object objDisplay = key.GetValue("DisplayVersion");
                        if (objDisplay == null) objDisplay = key.GetValue("ReleaseId");
                        if (objDisplay != null) displayVer = objDisplay.ToString();

                        object objCsd = key.GetValue("CSDVersion");
                        if (objCsd != null) csdVer = objCsd.ToString();
                    }
                }
            }
            catch { }

            int buildInt = 0;
            if (!string.IsNullOrEmpty(buildNum))
            {
                int.TryParse(buildNum, out buildInt);
            }
            else
            {
                buildInt = Environment.OSVersion.Version.Build;
                buildNum = buildInt.ToString();
            }

            _osBuildNumber = buildNum;

            if (!string.IsNullOrEmpty(prodName))
            {
                // Normalize ProductName: on Windows 11, registry might still say "Windows 10 Pro" for build >= 22000
                if (buildInt >= 22000 && prodName.IndexOf("Windows 10", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    prodName = prodName.Replace("Windows 10", "Windows 11");
                }

                _osFriendlyName = prodName;
                return;
            }

            // Fallback to Environment.OSVersion parsing
            Version osVer = Environment.OSVersion.Version;
            int major = osVer.Major;
            int minor = osVer.Minor;

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                if (major == 5 && minor == 0) _osFriendlyName = "Windows 2000";
                else if (major == 5 && minor == 1) _osFriendlyName = "Windows XP";
                else if (major == 5 && minor == 2) _osFriendlyName = "Windows Server 2003 / XP 64-bit";
                else if (major == 6 && minor == 0) _osFriendlyName = "Windows Vista";
                else if (major == 6 && minor == 1) _osFriendlyName = "Windows 7";
                else if (major == 6 && minor == 2) _osFriendlyName = "Windows 8";
                else if (major == 6 && minor == 3) _osFriendlyName = "Windows 8.1";
                else if (major == 10 && buildInt >= 22000) _osFriendlyName = "Windows 11";
                else if (major >= 10) _osFriendlyName = "Windows 10";
                else _osFriendlyName = string.Format("Windows NT {0}.{1}", major, minor);

                if (!string.IsNullOrEmpty(csdVer))
                {
                    _osFriendlyName = string.Format("{0} {1}", _osFriendlyName, csdVer);
                }
            }
            else
            {
                _osFriendlyName = Environment.OSVersion.ToString();
            }
        }
    }
}
