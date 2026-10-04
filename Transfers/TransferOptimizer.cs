using System;
using XpressShare.Network;
using XpressShare.Protocol;
using XpressShare.Utilities;

namespace XpressShare.Transfers
{
    /// <summary>
    /// Dynamic transfer optimizer implementing the core rule:
    /// Hardware detection -> Capability profile -> Network measurement -> Transfer profile -> Adaptive tuning.
    /// Ensures Pentium 4 + 2GB RAM gets a completely different profile from Ryzen 7 + 32GB RAM + NVMe + Gigabit.
    /// </summary>
    public static class TransferOptimizer
    {
        /// <summary>
        /// Analyzes system capabilities, file characteristics, and network link to produce an optimized transfer plan.
        /// </summary>
        public static PerformanceProfile OptimizeTransfer(long fileSizeBytes, NetworkCapabilities netCaps)
        {
            SystemCapabilities caps = SystemCapabilities.Current;
            PerformanceProfile profile = PerformanceProfile.DetectBestProfile(caps);

            // Adapt based on Network Medium (Wi-Fi vs Wired)
            if (caps.ActiveNetworkMedium == NetworkMedium.WiFi)
            {
                // Wi-Fi: prefer smaller chunks to minimize retransmission cost on packet loss or roaming jitter
                if (profile.ChunkSize > 128 * 1024)
                {
                    profile.ChunkSize = 128 * 1024;
                }
                profile.SelectionReason += " (Tuned for Wi-Fi jitter & stability)";
            }
            else if (caps.ActiveNetworkMedium == NetworkMedium.Ethernet && caps.LinkSpeedBps >= 1000000000)
            {
                // Gigabit Ethernet: scale up chunk size for large files on capable CPUs
                if (fileSizeBytes > 50 * 1024 * 1024 && caps.LogicalCoreCount >= 4)
                {
                    profile.ChunkSize = Math.Max(profile.ChunkSize, 256 * 1024);
                    profile.SelectionReason += " (Tuned for Gigabit Ethernet throughput)";
                }
            }

            // Adapt based on Storage Type (HDD vs SSD)
            if (caps.SystemStorageType == StorageType.HDD)
            {
                // Slow HDD: strictly 1 worker, sequential streaming to avoid thrashing disk heads
                profile.MaxConcurrentTransfers = 1;
                profile.PipeliningQueueDepth = 1;
            }

            return profile;
        }

        /// <summary>
        /// Generates a comprehensive system and network diagnostics report.
        /// </summary>
        public static string GetDiagnosticReport()
        {
            SystemCapabilities caps = SystemCapabilities.Current;
            PerformanceProfile profile = PerformanceProfile.DetectBestProfile(caps);

            ulong totalRamMb = caps.TotalPhysicalMemoryBytes / (1024UL * 1024UL);
            ulong availRamMb = caps.AvailablePhysicalMemoryBytes / (1024UL * 1024UL);

            return string.Format(
                "============================================================\r\n" +
                "XpressSHARE System & Transfer Diagnostics\r\n" +
                "============================================================\r\n" +
                "Operating System:     {0}\r\n" +
                ".NET Framework:       {1} (Compatible with .NET 3.5 on XP SP3)\r\n" +
                "Processor:            {2}\r\n" +
                "CPU Logical Cores:    {3} ({4})\r\n" +
                "Architecture:         {5}\r\n" +
                "Physical Memory:      {6:N0} MB total ({7:N0} MB available)\r\n" +
                "Storage Media:        {8}\r\n" +
                "Network Adapter:      {9}\r\n" +
                "Connection Medium:    {10}\r\n" +
                "Link Speed:           {11} Mbps\r\n" +
                "XPX Protocol:         XPX/1 (Application-layer independent of SMB)\r\n" +
                "Session Encryption:   AES-256-CBC + HMAC-SHA256 (Unique IV per packet)\r\n" +
                "Key Exchange:         2048-bit Ephemeral RSA + Nonce exchange\r\n" +
                "Performance Profile:  {12}\r\n" +
                "Profile Rationale:    {13}\r\n" +
                "Chunk Sizing:         {14} KB chunks (Buffer Pool: {15} KB)\r\n" +
                "Max Concurrency:      {16} concurrent transfers\r\n" +
                "Adaptive Compression:{17}\r\n" +
                "============================================================",
                caps.OperatingSystemName,
                Environment.Version,
                caps.CpuName,
                caps.LogicalCoreCount,
                caps.CoreCategory,
                caps.Architecture,
                totalRamMb,
                availRamMb,
                caps.SystemStorageType,
                caps.ActiveAdapterName,
                caps.ActiveNetworkMedium,
                caps.LinkSpeedBps > 0 ? (caps.LinkSpeedBps / 1000000).ToString() : "N/A",
                profile.ProfileName,
                profile.SelectionReason,
                profile.ChunkSize / 1024,
                profile.BufferSize / 1024,
                profile.MaxConcurrentTransfers,
                profile.AllowCompression ? "Enabled (Text/Logs only)" : "Disabled (Preserve CPU cycles)");
        }
    }
}
