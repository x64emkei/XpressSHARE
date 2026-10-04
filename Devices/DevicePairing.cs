using System;
using XpressShare.Security;

namespace XpressShare.Devices
{
    public enum DevicePairingState
    {
        Unpaired,
        PairingRequested,
        AwaitingPinConfirmation,
        Paired,
        Rejected,
        Revoked
    }

    /// <summary>
    /// Encapsulates pairing session state and credential verification between two devices.
    /// </summary>
    public class DevicePairing
    {
        public string RequestId { get; set; }
        public string RemoteDeviceId { get; set; }
        public string RemoteDeviceName { get; set; }
        public string RemoteIp { get; set; }
        public DevicePairingState State { get; set; }
        public string OneTimePin { get; set; }
        public string PairingToken { get; set; }
        public DateTime CreatedAt { get; set; }

        public DevicePairing()
        {
            RequestId = Guid.NewGuid().ToString();
            State = DevicePairingState.Unpaired;
            CreatedAt = DateTime.UtcNow;
        }

        public static DevicePairing StartPairing(string remoteDeviceId, string remoteDeviceName, string remoteIp)
        {
            DevicePairing pairing = new DevicePairing
            {
                RemoteDeviceId = remoteDeviceId,
                RemoteDeviceName = remoteDeviceName,
                RemoteIp = remoteIp,
                State = DevicePairingState.AwaitingPinConfirmation,
                OneTimePin = PairingManager.GenerateOneTimePin()
            };
            return pairing;
        }

        public bool Confirm(string enteredPin)
        {
            if (string.Equals(OneTimePin, enteredPin, StringComparison.Ordinal))
            {
                State = DevicePairingState.Paired;
                PairingToken = PairingManager.GeneratePairingToken();
                return true;
            }
            State = DevicePairingState.Rejected;
            return false;
        }
    }
}
