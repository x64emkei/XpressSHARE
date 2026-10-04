using System;
using System.IO;
using System.Net.NetworkInformation;
using XpressShare.Core;

namespace XpressShare.Services
{
    public enum ConnectionInterfaceType
    {
        Unknown,
        Loopback,
        Ethernet,
        WiFi
    }

    public class OptimizationProfile
    {
        public ConnectionInterfaceType InterfaceType { get; set; }
        public string InterfaceName { get; set; }
        public long LinkSpeedBps { get; set; }
        public int ChunkSizeBytes { get; set; }
        public int MaxParallelStreams { get; set; }
        public bool IsLowEndHardware { get; set; }
        public string SummaryDescription { get; set; }
    }

    public static class TransferOptimizer
    {
        public static OptimizationProfile DetectAndOptimize(long fileSizeBytes)
        {
            OptimizationProfile profile = new OptimizationProfile();

            // 1. Detect Hardware Capabilities
            int cpuCores = Environment.ProcessorCount;
            profile.IsLowEndHardware = (cpuCores <= 2);

            // 2. Detect Network Interface (Ethernet vs Wi-Fi vs Loopback)
            DetectNetworkInterface(profile);

            // 3. Select Appropriate Chunk Size & Streaming Settings
            if (profile.IsLowEndHardware)
            {
                // Low CPU: Conservative 32KB or 64KB buffers to avoid high GC / memory paging
                profile.ChunkSizeBytes = 32 * 1024;
                profile.MaxParallelStreams = 1;
            }
            else if (profile.InterfaceType == ConnectionInterfaceType.WiFi)
            {
                // Wi-Fi: Medium buffers (64KB) to handle packet jitter and packet loss cleanly
                profile.ChunkSizeBytes = 64 * 1024;
                profile.MaxParallelStreams = 2;
            }
            else if (profile.InterfaceType == ConnectionInterfaceType.Ethernet)
            {
                // Fast Wired LAN: High throughput buffers (128KB or 256KB for big files)
                if (fileSizeBytes > 10 * 1024 * 1024) // > 10MB
                {
                    profile.ChunkSizeBytes = 128 * 1024;
                }
                else
                {
                    profile.ChunkSizeBytes = 64 * 1024;
                }
                profile.MaxParallelStreams = 2;
            }
            else
            {
                profile.ChunkSizeBytes = 64 * 1024;
                profile.MaxParallelStreams = 1;
            }

            profile.SummaryDescription = string.Format(
                "{0} ({1} Mbps) - Optimized chunk: {2} KB - Parallel streams: {3}",
                profile.InterfaceType,
                profile.LinkSpeedBps > 0 ? (profile.LinkSpeedBps / 1000000).ToString() : "N/A",
                profile.ChunkSizeBytes / 1024,
                profile.MaxParallelStreams);

            AppLogger.Log("TransferOptimizer: " + profile.SummaryDescription);
            return profile;
        }

        public static ConnectionInterfaceType GetActiveConnectionType()
        {
            OptimizationProfile profile = new OptimizationProfile();
            DetectNetworkInterface(profile);
            return profile.InterfaceType;
        }

        private static void DetectNetworkInterface(OptimizationProfile profile)
        {
            profile.InterfaceType = ConnectionInterfaceType.Unknown;
            profile.InterfaceName = "Default Adapter";
            profile.LinkSpeedBps = 0;

            try
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    if (ni.OperationalStatus == OperationalStatus.Up &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                    {
                        if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                        {
                            profile.InterfaceType = ConnectionInterfaceType.WiFi;
                            profile.InterfaceName = ni.Name;
                            profile.LinkSpeedBps = ni.Speed;
                            return;
                        }
                        else if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                                 ni.NetworkInterfaceType == NetworkInterfaceType.GigabitEthernet)
                        {
                            profile.InterfaceType = ConnectionInterfaceType.Ethernet;
                            profile.InterfaceName = ni.Name;
                            profile.LinkSpeedBps = ni.Speed;
                            return;
                        }
                    }
                }

                // If only loopback is up
                foreach (NetworkInterface ni in interfaces)
                {
                    if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    {
                        profile.InterfaceType = ConnectionInterfaceType.Loopback;
                        profile.InterfaceName = ni.Name;
                        profile.LinkSpeedBps = 1000000000;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("TransferOptimizer.DetectNetworkInterface error: " + ex.Message);
            }
        }

        public static string GetDiagnosticReport()
        {
            return XpressShare.Transfers.TransferOptimizer.GetDiagnosticReport();
        }

        public static string GetOperatingSystemName()
        {
            try
            {
                Version v = Environment.OSVersion.Version;
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    if (v.Major == 10 && v.Build >= 22000)
                        return "Windows 11 Pro / Enterprise";
                    if (v.Major == 10)
                        return "Windows 10 (" + v.Build + ")";
                    if (v.Major == 6 && v.Minor == 3)
                        return "Windows 8.1";
                    if (v.Major == 6 && v.Minor == 2)
                        return "Windows 8";
                    if (v.Major == 6 && v.Minor == 1)
                        return "Windows 7 SP1";
                    if (v.Major == 6 && v.Minor == 0)
                        return "Windows Vista";
                    if (v.Major == 5 && v.Minor == 1)
                        return "Windows XP";
                }
            }
            catch { }
            return Environment.OSVersion.VersionString;
        }

        public static string GetSystemDiagnosticReport()
        {
            OptimizationProfile profile = DetectAndOptimize(0);
            return string.Format(
                "XpressSHARE System Diagnostics:\r\n" +
                "OS: {0}\r\n" +
                "CPU Logical Cores: {1}\r\n" +
                "Architecture: {2}\r\n" +
                "Network Interface: {3} ({4})\r\n" +
                "Link Speed: {5} Mbps\r\n" +
                "Auto Buffer Profile: {6} KB Chunks\r\n" +
                "Hardware Profile: {7}",
                GetOperatingSystemName(),
                Environment.ProcessorCount,
                IntPtr.Size == 4 ? "x86 (32-bit)" : "x64 (64-bit)",
                profile.InterfaceName,
                profile.InterfaceType,
                profile.LinkSpeedBps > 0 ? (profile.LinkSpeedBps / 1000000).ToString() : "Unknown",
                profile.ChunkSizeBytes / 1024,
                profile.IsLowEndHardware ? "Low-Resource" : "High-Performance");
        }
    }
}
