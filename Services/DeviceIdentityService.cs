using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using XpressShare.Core;
using XpressShare.Models;

namespace XpressShare.Services
{
    public class DeviceIdentityService
    {
        private DeviceIdentity _cachedIdentity;

        public DeviceIdentityService() { }

        public DeviceIdentity GetIdentity()
        {
            if (_cachedIdentity != null)
                return _cachedIdentity;

            string identityFile = Path.Combine(AppPaths.BasePath, "device.id");
            string deviceId = string.Empty;

            try
            {
                if (File.Exists(identityFile))
                {
                    deviceId = File.ReadAllText(identityFile).Trim();
                }

                if (string.IsNullOrEmpty(deviceId))
                {
                    deviceId = GenerateStableDeviceId();
                    File.WriteAllText(identityFile, deviceId);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("DeviceIdentityService error reading device ID: " + ex.Message);
                if (string.IsNullOrEmpty(deviceId))
                    deviceId = Guid.NewGuid().ToString("N");
            }

            string localIp = GetLocalIpAddress();
            _cachedIdentity = new DeviceIdentity
            {
                DeviceId = deviceId,
                DeviceName = Environment.MachineName,
                LocalIpAddress = localIp
            };

            return _cachedIdentity;
        }

        private string GenerateStableDeviceId()
        {
            // Try to use MAC address as stable identifier
            try
            {
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    if (adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        adapter.OperationalStatus == OperationalStatus.Up)
                    {
                        string mac = adapter.GetPhysicalAddress().ToString();
                        if (!string.IsNullOrEmpty(mac))
                        {
                            return mac.Replace("-", "").ToLower();
                        }
                    }
                }
            }
            catch
            {
            }

            // Fallback to machine name + random
            return (Environment.MachineName + Guid.NewGuid().ToString("N")).GetHashCode().ToString("X8");
        }

        private string GetLocalIpAddress()
        {
            try
            {
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    if (adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        adapter.OperationalStatus == OperationalStatus.Up)
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                string ipStr = ip.Address.ToString();
                                if (!ipStr.StartsWith("127.") && !ipStr.StartsWith("169.254."))
                                    return ipStr;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("DeviceIdentityService error getting local IP: " + ex.Message);
            }

            return "127.0.0.1";
        }
    }
}
