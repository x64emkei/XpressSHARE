using System;

namespace XpressShare.Utilities
{
    public enum PerformanceProfileType
    {
        UltraLow = 0,
        Low = 1,
        Balanced = 2,
        Performance = 3,
        HighPerformance = 4
    }

    /// <summary>
    /// Automatic hardware-driven performance profile.
    /// Balances CPU, RAM, storage, and network bandwidth to avoid overloading legacy systems
    /// while maximizing throughput on modern workstations.
    /// </summary>
    public class PerformanceProfile
    {
        public PerformanceProfileType ProfileType { get; set; }
        public string ProfileName { get; set; }
        public string SelectionReason { get; set; }

        public int ChunkSize { get; set; }
        public int BufferSize { get; set; }
        public int MaxConcurrentTransfers { get; set; }
        public int PipeliningQueueDepth { get; set; }
        public bool AllowCompression { get; set; }
        public int HeartbeatIntervalMs { get; set; }
        public int SocketTimeoutMs { get; set; }

        public static PerformanceProfile CreateUltraLow(string reason)
        {
            return new PerformanceProfile
            {
                ProfileType = PerformanceProfileType.UltraLow,
                ProfileName = "Ultra-Low Resource",
                SelectionReason = reason ?? "Single-core CPU or very low RAM (< 1.5 GB), slow HDD",
                ChunkSize = 32 * 1024, // 32 KB
                BufferSize = 32 * 1024,
                MaxConcurrentTransfers = 1,
                PipeliningQueueDepth = 1,
                AllowCompression = false, // Save CPU cycles on Pentium / Atom
                HeartbeatIntervalMs = 15000, // Infrequent to prevent waking CPU
                SocketTimeoutMs = 45000
            };
        }

        public static PerformanceProfile CreateLow(string reason)
        {
            return new PerformanceProfile
            {
                ProfileType = PerformanceProfileType.Low,
                ProfileName = "Low Resource",
                SelectionReason = reason ?? "Dual-core CPU or 2–4 GB RAM, standard HDD",
                ChunkSize = 64 * 1024, // 64 KB
                BufferSize = 64 * 1024,
                MaxConcurrentTransfers = 1,
                PipeliningQueueDepth = 1,
                AllowCompression = false,
                HeartbeatIntervalMs = 10000,
                SocketTimeoutMs = 35000
            };
        }

        public static PerformanceProfile CreateBalanced(string reason)
        {
            return new PerformanceProfile
            {
                ProfileType = PerformanceProfileType.Balanced,
                ProfileName = "Balanced",
                SelectionReason = reason ?? "Quad-core CPU, 4–8 GB RAM, standard network",
                ChunkSize = 128 * 1024, // 128 KB
                BufferSize = 128 * 1024,
                MaxConcurrentTransfers = 2,
                PipeliningQueueDepth = 2,
                AllowCompression = true,
                HeartbeatIntervalMs = 8000,
                SocketTimeoutMs = 30000
            };
        }

        public static PerformanceProfile CreatePerformance(string reason)
        {
            return new PerformanceProfile
            {
                ProfileType = PerformanceProfileType.Performance,
                ProfileName = "Performance",
                SelectionReason = reason ?? "Multi-core CPU (6+ cores), 8+ GB RAM, SSD, Gigabit LAN",
                ChunkSize = 256 * 1024, // 256 KB
                BufferSize = 256 * 1024,
                MaxConcurrentTransfers = 3,
                PipeliningQueueDepth = 4,
                AllowCompression = true,
                HeartbeatIntervalMs = 5000,
                SocketTimeoutMs = 25000
            };
        }

        public static PerformanceProfile CreateHighPerformance(string reason)
        {
            return new PerformanceProfile
            {
                ProfileType = PerformanceProfileType.HighPerformance,
                ProfileName = "High Performance",
                SelectionReason = reason ?? "Many-core CPU (8+ cores), 16+ GB RAM, NVMe SSD, Multi-Gigabit LAN",
                ChunkSize = 512 * 1024, // 512 KB
                BufferSize = 512 * 1024,
                MaxConcurrentTransfers = 4, // Hard upper limit to prevent memory/CPU exhaustion
                PipeliningQueueDepth = 6,
                AllowCompression = true,
                HeartbeatIntervalMs = 5000,
                SocketTimeoutMs = 20000
            };
        }

        /// <summary>
        /// Automatically analyzes system capabilities to select the optimal profile.
        /// </summary>
        public static PerformanceProfile DetectBestProfile(SystemCapabilities caps)
        {
            if (caps == null)
                caps = SystemCapabilities.Current;

            int cores = caps.LogicalCoreCount;
            ulong ramMb = caps.TotalPhysicalMemoryBytes / (1024UL * 1024UL);
            bool isSsd = caps.SystemStorageType == StorageType.SSD;
            long linkSpeedMbps = caps.LinkSpeedBps > 0 ? caps.LinkSpeedBps / 1000000 : 100;
            bool isWifi = caps.ActiveNetworkMedium == NetworkMedium.WiFi;

            // 1. Single core or < 1.5 GB RAM -> UltraLow
            if (cores <= 1 || ramMb < 1536 || caps.IsWindowsXpOrOlder)
            {
                string reason = string.Format("{0} CPU core(s), {1} MB RAM, {2} ({3})",
                    cores, ramMb, caps.OperatingSystemName, isWifi ? "Wi-Fi" : "Ethernet");
                return CreateUltraLow(reason);
            }

            // 2. Dual core or < 4 GB RAM -> Low
            if (cores <= 2 || ramMb < 4096)
            {
                string reason = string.Format("{0} CPU cores, {1:0.0} GB RAM, {2}",
                    cores, ramMb / 1024.0, isSsd ? "SSD" : "HDD");
                return CreateLow(reason);
            }

            // 3. High Performance: 8+ cores, 16+ GB RAM, SSD, Gigabit or faster wired
            if (cores >= 8 && ramMb >= 16384 && isSsd && linkSpeedMbps >= 1000 && !isWifi)
            {
                string reason = string.Format("{0} CPU cores, {1:0.0} GB RAM, NVMe/SSD, {2} Mbps Gigabit LAN",
                    cores, ramMb / 1024.0, linkSpeedMbps);
                return CreateHighPerformance(reason);
            }

            // 4. Performance: 6+ cores, 8+ GB RAM, SSD, Fast LAN/Wi-Fi
            if (cores >= 6 && ramMb >= 8192 && isSsd)
            {
                string reason = string.Format("{0} CPU cores, {1:0.0} GB RAM, SSD, {2} ({3} Mbps)",
                    cores, ramMb / 1024.0, isWifi ? "Wi-Fi" : "LAN", linkSpeedMbps);
                return CreatePerformance(reason);
            }

            // 5. Default: Balanced
            string balReason = string.Format("{0} CPU cores, {1:0.0} GB RAM, {2}, {3}",
                cores, ramMb / 1024.0, isSsd ? "SSD" : "HDD", isWifi ? "Wi-Fi" : "Ethernet");
            return CreateBalanced(balReason);
        }
    }
}
