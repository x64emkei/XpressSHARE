using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using XpressShare.Storage;

namespace XpressShare.Security
{
    public class PairingRequestInfo
    {
        public string RequestId { get; set; }
        public string InitiatorDeviceId { get; set; }
        public string InitiatorDeviceName { get; set; }
        public string InitiatorIp { get; set; }
        public string OneTimePin { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

    /// <summary>
    /// Manages secure zero-knowledge device pairing without transmitting passwords.
    /// Uses cryptographically signed pairing tokens and 6-digit one-time confirmation codes.
    /// </summary>
    public class PairingManager
    {
        private readonly TrustedDeviceRepository _repository;
        private readonly Dictionary<string, PairingRequestInfo> _pendingRequests;
        private readonly object _lock = new object();

        public PairingManager()
        {
            _repository = new TrustedDeviceRepository();
            _pendingRequests = new Dictionary<string, PairingRequestInfo>();
        }

        /// <summary>
        /// Generates a secure 6-digit one-time PIN using RNGCryptoServiceProvider.
        /// </summary>
        public static string GenerateOneTimePin()
        {
            byte[] bytes = CryptoProvider.GenerateRandomBytes(4);
            uint num = BitConverter.ToUInt32(bytes, 0) % 1000000;
            return num.ToString("D6");
        }

        /// <summary>
        /// Generates a long-lived cryptographically secure pairing credential token.
        /// </summary>
        public static string GeneratePairingToken()
        {
            byte[] raw = CryptoProvider.GenerateRandomBytes(32);
            return CryptoProvider.ToHex(raw);
        }

        /// <summary>
        /// Initiates a pairing request from this device to a remote peer.
        /// </summary>
        public PairingRequestInfo CreatePairingRequest(string initiatorId, string initiatorName, string initiatorIp)
        {
            PairingRequestInfo req = new PairingRequestInfo
            {
                RequestId = Guid.NewGuid().ToString(),
                InitiatorDeviceId = initiatorId,
                InitiatorDeviceName = initiatorName,
                InitiatorIp = initiatorIp,
                OneTimePin = GenerateOneTimePin(),
                ExpiresAt = DateTime.UtcNow.AddMinutes(5)
            };

            lock (_lock)
            {
                _pendingRequests[req.RequestId] = req;
            }

            return req;
        }

        /// <summary>
        /// Verifies confirmation PIN and establishes permanent trusted device credential.
        /// </summary>
        public bool ConfirmPairing(string requestId, string enteredPin, out string pairingToken)
        {
            pairingToken = null;
            lock (_lock)
            {
                PairingRequestInfo req;
                if (!_pendingRequests.TryGetValue(requestId, out req))
                    return false;

                if (DateTime.UtcNow > req.ExpiresAt)
                {
                    _pendingRequests.Remove(requestId);
                    return false;
                }

                if (!string.Equals(req.OneTimePin, enteredPin, StringComparison.Ordinal))
                    return false;

                _pendingRequests.Remove(requestId);
                pairingToken = GeneratePairingToken();
                return true;
            }
        }

        /// <summary>
        /// Checks if a device has a valid trusted pairing credential.
        /// </summary>
        public bool IsDeviceTrusted(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId)) return false;
            return _repository.Load(deviceId) != null;
        }

        /// <summary>
        /// Registers a completed pairing in persistent storage.
        /// </summary>
        public void RegisterTrustedDevice(string deviceId, string deviceName, string ipAddress, string connectionType, string pairingToken)
        {
            var device = new Models.TrustedDevice
            {
                DeviceId = deviceId,
                Name = deviceName,
                IpAddress = ipAddress,
                ConnectionType = connectionType,
                PairingToken = pairingToken ?? GeneratePairingToken(),
                TrustedSince = DateTime.UtcNow,
                LastUsed = DateTime.UtcNow
            };
            _repository.Save(device);
        }

        /// <summary>
        /// Revokes pairing for a specific device.
        /// </summary>
        public void RevokeDevice(string deviceId)
        {
            _repository.Delete(deviceId);
        }

        /// <summary>
        /// Revokes all paired devices.
        /// </summary>
        public void RevokeAllDevices()
        {
            List<Models.TrustedDevice> all = _repository.LoadAll();
            foreach (Models.TrustedDevice d in all)
            {
                _repository.Delete(d.DeviceId);
            }
        }

        /// <summary>
        /// Lists all trusted devices.
        /// </summary>
        public List<Models.TrustedDevice> GetTrustedDevices()
        {
            return _repository.LoadAll();
        }
    }
}
