using System;

namespace XpressShare.Protocol
{
    /// <summary>
    /// Protocol constants for the XPX/1 application-layer protocol.
    /// Fully deterministic and compatible with .NET 3.5 on Windows XP SP3 through Windows 11.
    /// </summary>
    public static class XpxProtocolConstants
    {
        /// <summary>
        /// Magic identifier: "XPX1" in ASCII (0x58, 0x50, 0x58, 0x31)
        /// </summary>
        public const uint Magic = 0x58505831;

        /// <summary>
        /// Protocol major version: 1
        /// </summary>
        public const byte ProtocolVersion = 1;

        /// <summary>
        /// Fixed binary header length in bytes.
        /// [0..3] Magic (4)
        /// [4] Version (1)
        /// [5] PacketType (1)
        /// [6..7] Flags (2)
        /// [8..9] HeaderLength (2)
        /// [10..13] PayloadLength (4)
        /// [14..21] PacketId (8)
        /// [22..37] SessionId (16)
        /// [38..41] Crc32 (4)
        /// Total = 42 bytes.
        /// </summary>
        public const ushort HeaderLength = 42;

        /// <summary>
        /// Fixed length of HMAC-SHA256 authentication tag in bytes.
        /// </summary>
        public const int HmacLength = 32;

        /// <summary>
        /// AES block size / IV size in bytes (128 bits).
        /// </summary>
        public const int AesBlockSize = 16;

        /// <summary>
        /// AES-256 key size in bytes.
        /// </summary>
        public const int AesKeySize = 32;

        /// <summary>
        /// HMAC-SHA256 key size in bytes.
        /// </summary>
        public const int HmacKeySize = 32;

        /// <summary>
        /// Default TCP port for XPX transfer connections.
        /// </summary>
        public const int DefaultTransferPort = 15001;

        /// <summary>
        /// Default UDP port for XPX device discovery.
        /// </summary>
        public const int DefaultDiscoveryPort = 15000;

        /// <summary>
        /// Hard upper limit on payload size (4 MB) to prevent untrusted allocations
        /// and protect low-memory legacy machines (e.g. 512MB RAM Pentium systems).
        /// </summary>
        public const int MaxPayloadLength = 4 * 1024 * 1024;

        /// <summary>
        /// Maximum allowable file chunk size (1 MB) for modern high-performance systems.
        /// </summary>
        public const int MaxChunkSize = 1024 * 1024;

        /// <summary>
        /// Minimum allowable file chunk size (16 KB) for ultra-low resource systems.
        /// </summary>
        public const int MinChunkSize = 16 * 1024;

        /// <summary>
        /// Default file chunk size (64 KB).
        /// </summary>
        public const int DefaultChunkSize = 64 * 1024;

        /// <summary>
        /// Default socket read/write timeout in milliseconds.
        /// </summary>
        public const int DefaultSocketTimeoutMs = 30000;

        /// <summary>
        /// Default heartbeat interval in milliseconds (10 seconds).
        /// </summary>
        public const int DefaultHeartbeatIntervalMs = 10000;

        /// <summary>
        /// Heartbeat timeout before marking connection dead (30 seconds).
        /// </summary>
        public const int HeartbeatTimeoutMs = 30000;

        /// <summary>
        /// Maximum reconnect attempts before giving up.
        /// </summary>
        public const int MaxReconnectAttempts = 4;
    }
}
