using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using XpressShare.Core;

namespace XpressShare.Services
{
    public class AccessPinService
    {
        private class PinEntry
        {
            public string Pin { get; set; }
            public DateTime ExpiresAt { get; set; }
        }

        private const int PinLength = 4;
        private const int PinValiditySeconds = 60;
        private readonly Dictionary<string, PinEntry> _activePins = new Dictionary<string, PinEntry>();
        private readonly object _lockObj = new object();

        public AccessPinService() { }

        public string GeneratePin()
        {
            lock (_lockObj)
            {
                string pin = GenerateRandomPin();
                var entry = new PinEntry
                {
                    Pin = pin,
                    ExpiresAt = DateTime.UtcNow.AddSeconds(PinValiditySeconds)
                };
                _activePins[pin] = entry;
                return pin;
            }
        }

        public bool ValidatePin(string pin)
        {
            if (string.IsNullOrEmpty(pin))
                return false;

            lock (_lockObj)
            {
                PinEntry entry;
                if (!_activePins.TryGetValue(pin, out entry))
                    return false;

                if (DateTime.UtcNow > entry.ExpiresAt)
                {
                    _activePins.Remove(pin);
                    return false;
                }

                return true;
            }
        }

        public void InvalidatePin(string pin)
        {
            if (string.IsNullOrEmpty(pin))
                return;

            lock (_lockObj)
            {
                _activePins.Remove(pin);
            }
        }

        public void CleanupExpiredPins()
        {
            lock (_lockObj)
            {
                List<string> expired = new List<string>();
                foreach (var kvp in _activePins)
                {
                    if (DateTime.UtcNow > kvp.Value.ExpiresAt)
                        expired.Add(kvp.Key);
                }
                foreach (string pin in expired)
                {
                    _activePins.Remove(pin);
                }
            }
        }

        private string GenerateRandomPin()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] data = new byte[4];
            rng.GetBytes(data);
            int value = (BitConverter.ToInt32(data, 0) & 0x7FFFFFFF) % 10000;
            return value.ToString("D4");
        }
    }
}
