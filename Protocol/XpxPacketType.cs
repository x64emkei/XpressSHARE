using System;

namespace XpressShare.Protocol
{
    /// <summary>
    /// Packet types for the XPX/1 binary protocol.
    /// Explicit 1-byte numeric values for cross-generation stability.
    /// </summary>
    public enum XpxPacketType : byte
    {
        Unknown = 0,

        // Session & Key Exchange
        Hello = 1,
        HelloAck = 2,
        CapabilitiesNegotiate = 3,
        CapabilitiesAck = 4,

        // Authentication & Pairing
        Authentication = 5,
        AuthenticationResult = 6,
        PairRequest = 7,
        PairResponse = 8,

        // Messaging
        Message = 9,
        MessageAck = 10,

        // File Transfer
        FileRequest = 11,
        FileResponse = 12,
        FileChunk = 13,
        FileChunkAck = 14,
        FileComplete = 15,
        FileCancel = 16,

        // Heartbeat & Connection Health
        Heartbeat = 17,
        HeartbeatAck = 18,

        // Control & Errors
        Disconnect = 19,
        Error = 20,
        EndOfStream = 21
    }
}
