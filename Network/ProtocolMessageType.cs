namespace XpressShare.Network
{
    public enum ProtocolMessageType
    {
        Identity,           // Device announces itself
        IdentityRequest,    // Request identity info from device
        PairingRequest,     // Request to pair with a device
        PairingAccept,      // Accept pairing request
        PairingReject,      // Reject pairing request
        TransferStart,      // Start file transfer session
        TransferAccept,     // Receiver accepts the transfer
        TransferReject,     // Receiver rejects the transfer
        TransferData,       // File data chunk
        TransferComplete,   // Transfer finished
        TransferCancel,     // Cancel transfer
        PingRequest,        // Keep-alive ping
        PingResponse,       // Keep-alive pong
        Error               // Error message
    }
}
