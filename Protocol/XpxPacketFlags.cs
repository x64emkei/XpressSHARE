using System;

namespace XpressShare.Protocol
{
    /// <summary>
    /// Flags for the XPX/1 binary packet header (16-bit bitmask).
    /// </summary>
    [Flags]
    public enum XpxPacketFlags : ushort
    {
        None = 0x0000,

        /// <summary>
        /// Payload is encrypted with AES-256-CBC and signed with HMAC-SHA256.
        /// </summary>
        Encrypted = 0x0001,

        /// <summary>
        /// Payload is compressed (Deflate).
        /// </summary>
        Compressed = 0x0002,

        /// <summary>
        /// First chunk or message in a multi-packet sequence.
        /// </summary>
        First = 0x0004,

        /// <summary>
        /// Last chunk or message in a multi-packet sequence.
        /// </summary>
        Last = 0x0008,

        /// <summary>
        /// Packet is a response to a prior request.
        /// </summary>
        Response = 0x0010,

        /// <summary>
        /// Packet signals an error condition.
        /// </summary>
        Error = 0x0020,

        /// <summary>
        /// Transfer is a resumption from an existing partial byte offset.
        /// </summary>
        Resumed = 0x0040,

        /// <summary>
        /// Sender requests an immediate acknowledgment (ACK).
        /// </summary>
        RequiresAck = 0x0080
    }
}
