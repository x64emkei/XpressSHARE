using System;
using System.Collections.Generic;
using XpressShare.Core;
using XpressShare.Models;
using XpressShare.Storage;

namespace XpressShare.Services
{
    public class TrustedDeviceService
    {
        private readonly TrustedDeviceRepository _repository;

        public TrustedDeviceService()
        {
            _repository = new TrustedDeviceRepository();
        }

        public List<TrustedDevice> GetTrustedDevices()
        {
            try
            {
                return _repository.LoadAll();
            }
            catch (Exception ex)
            {
                AppLogger.Log("TrustedDeviceService.GetTrustedDevices error: " + ex.Message);
                return new List<TrustedDevice>();
            }
        }

        public bool IsTrusted(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
                return false;

            try
            {
                return _repository.Load(deviceId) != null;
            }
            catch (Exception ex)
            {
                AppLogger.Log("TrustedDeviceService.IsTrusted error: " + ex.Message);
                return false;
            }
        }

        public void AddTrustedDevice(string deviceId, string deviceName)
        {
            PairDevice(deviceId, deviceName, "127.0.0.1", "Ethernet");
        }

        public TrustedDevice PairDevice(string deviceId, string deviceName, string ipAddress, string connectionType)
        {
            if (string.IsNullOrEmpty(deviceId))
                return null;

            try
            {
                string pairingToken = Guid.NewGuid().ToString("N");
                var device = new TrustedDevice
                {
                    DeviceId = deviceId,
                    Name = string.IsNullOrEmpty(deviceName) ? deviceId : deviceName,
                    IpAddress = ipAddress ?? "127.0.0.1",
                    ConnectionType = string.IsNullOrEmpty(connectionType) ? "Ethernet" : connectionType,
                    PairingToken = pairingToken,
                    TrustedSince = DateTime.UtcNow,
                    LastUsed = DateTime.UtcNow
                };
                _repository.Save(device);
                AppLogger.Log("Device paired securely: " + device.Name + " (" + device.DeviceId + ")");
                return device;
            }
            catch (Exception ex)
            {
                AppLogger.Log("TrustedDeviceService.PairDevice error: " + ex.Message);
                return null;
            }
        }

        public void UpdateLastUsed(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId)) return;
            try
            {
                var dev = _repository.Load(deviceId);
                if (dev != null)
                {
                    dev.LastUsed = DateTime.UtcNow;
                    _repository.Save(dev);
                }
            }
            catch { }
        }

        public void RemoveTrustedDevice(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
                return;

            try
            {
                _repository.Delete(deviceId);
            }
            catch (Exception ex)
            {
                AppLogger.Log("TrustedDeviceService.RemoveTrustedDevice error: " + ex.Message);
            }
        }

        public TrustedDevice GetTrustedDevice(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
                return null;

            try
            {
                return _repository.Load(deviceId);
            }
            catch (Exception ex)
            {
                AppLogger.Log("TrustedDeviceService.GetTrustedDevice error: " + ex.Message);
                return null;
            }
        }
    }
}
