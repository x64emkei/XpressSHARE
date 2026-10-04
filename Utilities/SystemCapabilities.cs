using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace XpressShare.Utilities
{
    public enum CpuCoreCategory
    {
        SingleCore = 1,
        DualCore = 2,
        QuadCore = 4,
        ManyCore = 8
    }

    public enum StorageType
    {
        Unknown,
        HDD,
        SSD,
        RemovableOrUsb,
        NetworkDrive
    }

    public enum NetworkMedium
    {
        Unknown,
        Loopback,
        Ethernet,
        WiFi
    }

    /// <summary>
    /// Comprehensive hardware and environment detection component.
    /// Operates safely from Windows XP SP3 through Windows 11 without crashing.
    /// </summary>
    public class SystemCapabilities
    {
        private static SystemCapabilities _current;
        private static readonly object _syncLock = new object();

        public static SystemCapabilities Current
        {
            get
            {
                if (_current == null)
                {
                    lock (_syncLock)
                    {
                        if (_current == null)
                        {
                            _current = Detect();
                        }
                    }
                }
                return _current;
            }
        }

        public string CpuName { get; private set; }
        public int LogicalCoreCount { get; private set; }
        public CpuCoreCategory CoreCategory { get; private set; }
        public string Architecture { get; private set; }

        public ulong TotalPhysicalMemoryBytes { get; private set; }
        public ulong AvailablePhysicalMemoryBytes { get; private set; }

        public string OperatingSystemName { get; private set; }
        public Version OsVersion { get; private set; }
        public bool IsWindowsXpOrOlder { get; private set; }

        public NetworkMedium ActiveNetworkMedium { get; private set; }
        public string ActiveAdapterName { get; private set; }
        public long LinkSpeedBps { get; private set; }

        public StorageType SystemStorageType { get; private set; }
        public long SystemDriveFreeSpaceBytes { get; private set; }

        private SystemCapabilities() { }

        public static SystemCapabilities Detect()
        {
            SystemCapabilities caps = new SystemCapabilities();

            caps.DetectCpu();
            caps.DetectMemory();
            caps.DetectOperatingSystem();
            caps.DetectNetwork();
            caps.DetectStorage();

            return caps;
        }

        private void DetectCpu()
        {
            LogicalCoreCount = Environment.ProcessorCount;
            if (LogicalCoreCount <= 1)
                CoreCategory = CpuCoreCategory.SingleCore;
            else if (LogicalCoreCount == 2)
                CoreCategory = CpuCoreCategory.DualCore;
            else if (LogicalCoreCount <= 4)
                CoreCategory = CpuCoreCategory.QuadCore;
            else
                CoreCategory = CpuCoreCategory.ManyCore;

            Architecture = IntPtr.Size == 4 ? "x86 (32-bit)" : "x64 (64-bit)";

            // Read friendly CPU name from registry
            CpuName = "Unknown Processor";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0"))
                {
                    if (key != null)
                    {
                        object nameVal = key.GetValue("ProcessorNameString");
                        if (nameVal != null)
                        {
                            CpuName = nameVal.ToString().Trim();
                        }
                    }
                }
            }
            catch
            {
                string procId = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
                if (!string.IsNullOrEmpty(procId))
                    CpuName = procId;
            }
        }

        private void DetectMemory()
        {
            TotalPhysicalMemoryBytes = 0;
            AvailablePhysicalMemoryBytes = 0;

            try
            {
                MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
                memStatus.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
                if (GlobalMemoryStatusEx(ref memStatus))
                {
                    TotalPhysicalMemoryBytes = memStatus.ullTotalPhys;
                    AvailablePhysicalMemoryBytes = memStatus.ullAvailPhys;
                }
            }
            catch
            {
                // Fallback estimate if GlobalMemoryStatusEx fails
                TotalPhysicalMemoryBytes = 1024UL * 1024UL * 1024UL; // 1 GB fallback
                AvailablePhysicalMemoryBytes = 512UL * 1024UL * 1024UL;
            }
        }

        private void DetectOperatingSystem()
        {
            OsVersion = Environment.OSVersion.Version;
            OperatingSystemName = Environment.OSVersion.VersionString;
            IsWindowsXpOrOlder = false;

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                int major = OsVersion.Major;
                int minor = OsVersion.Minor;
                int build = OsVersion.Build;

                if (major == 5 && minor == 1)
                {
                    OperatingSystemName = "Windows XP SP3";
                    IsWindowsXpOrOlder = true;
                }
                else if (major == 5 && minor == 2)
                {
                    OperatingSystemName = "Windows Server 2003 / XP 64-bit";
                    IsWindowsXpOrOlder = true;
                }
                else if (major == 6 && minor == 0)
                {
                    OperatingSystemName = "Windows Vista";
                }
                else if (major == 6 && minor == 1)
                {
                    OperatingSystemName = "Windows 7 SP1";
                }
                else if (major == 6 && minor == 2)
                {
                    OperatingSystemName = "Windows 8";
                }
                else if (major == 6 && minor == 3)
                {
                    OperatingSystemName = "Windows 8.1";
                }
                else if (major == 10 && build >= 22000)
                {
                    OperatingSystemName = "Windows 11 (Build " + build + ")";
                }
                else if (major >= 10)
                {
                    OperatingSystemName = "Windows 10 (Build " + build + ")";
                }
            }
        }

        private void DetectNetwork()
        {
            ActiveNetworkMedium = NetworkMedium.Unknown;
            ActiveAdapterName = "Default Network Adapter";
            LinkSpeedBps = 0;

            try
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    if (ni.OperationalStatus == OperationalStatus.Up &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                    {
                        string desc = (ni.Description ?? "").ToLowerInvariant();
                        bool isWireless = (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) ||
                                          desc.Contains("wi-fi") || desc.Contains("wireless") || desc.Contains("802.11");

                        if (isWireless)
                        {
                            ActiveNetworkMedium = NetworkMedium.WiFi;
                            ActiveAdapterName = ni.Name;
                            LinkSpeedBps = ni.Speed;
                            return;
                        }

                        if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                            ni.NetworkInterfaceType == NetworkInterfaceType.GigabitEthernet ||
                            desc.Contains("ethernet") || desc.Contains("lan") || desc.Contains("gigabit"))
                        {
                            ActiveNetworkMedium = NetworkMedium.Ethernet;
                            ActiveAdapterName = ni.Name;
                            LinkSpeedBps = ni.Speed;
                            return;
                        }
                    }
                }

                // If only loopback is present
                ActiveNetworkMedium = NetworkMedium.Loopback;
                ActiveAdapterName = "Loopback Adapter";
                LinkSpeedBps = 1000000000;
            }
            catch
            {
                ActiveNetworkMedium = NetworkMedium.Unknown;
            }
        }

        private void DetectStorage()
        {
            SystemStorageType = StorageType.HDD; // Conservative default for legacy XP/7
            SystemDriveFreeSpaceBytes = 0;

            try
            {
                string sysDrive = Path.GetPathRoot(Environment.SystemDirectory);
                if (string.IsNullOrEmpty(sysDrive))
                    sysDrive = "C:\\";

                DriveInfo dInfo = new DriveInfo(sysDrive);
                if (dInfo.IsReady)
                {
                    SystemDriveFreeSpaceBytes = dInfo.AvailableFreeSpace;
                    if (dInfo.DriveType == DriveType.Removable)
                    {
                        SystemStorageType = StorageType.RemovableOrUsb;
                        return;
                    }
                    if (dInfo.DriveType == DriveType.Network)
                    {
                        SystemStorageType = StorageType.NetworkDrive;
                        return;
                    }
                }

                // Modern Windows (Win8+) typically has SSDs; XP is almost always HDD
                if (OsVersion.Major >= 10)
                {
                    SystemStorageType = StorageType.SSD;
                }
                else if (IsWindowsXpOrOlder)
                {
                    SystemStorageType = StorageType.HDD;
                }
            }
            catch
            {
                SystemStorageType = StorageType.HDD;
            }
        }

        #region Win32 Native Interop

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

        #endregion
    }
}
