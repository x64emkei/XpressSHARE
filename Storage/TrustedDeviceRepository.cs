using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XpressShare.Core;
using XpressShare.Models;

namespace XpressShare.Storage
{
    public class TrustedDeviceRepository
    {
        private readonly string _filePath;
        private readonly object _lockObj = new object();

        public TrustedDeviceRepository()
        {
            _filePath = Path.Combine(AppPaths.BasePath, "trusted.json");
        }

        public void Save(TrustedDevice device)
        {
            if (device == null)
                throw new ArgumentNullException("device");

            lock (_lockObj)
            {
                try
                {
                    List<TrustedDevice> devices = LoadAll();
                    int index = devices.FindIndex(d => d.DeviceId == device.DeviceId);
                    if (index >= 0)
                        devices[index] = device;
                    else
                        devices.Add(device);

                    SaveAllInternal(devices);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("TrustedDeviceRepository.Save error: " + ex.Message);
                    throw;
                }
            }
        }

        public TrustedDevice Load(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
                return null;

            lock (_lockObj)
            {
                try
                {
                    List<TrustedDevice> devices = LoadAll();
                    return devices.Find(d => d.DeviceId == deviceId);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("TrustedDeviceRepository.Load error: " + ex.Message);
                    return null;
                }
            }
        }

        public List<TrustedDevice> LoadAll()
        {
            lock (_lockObj)
            {
                try
                {
                    if (!File.Exists(_filePath))
                        return new List<TrustedDevice>();

                    string json = File.ReadAllText(_filePath, Encoding.UTF8);
                    return DeserializeDevices(json);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("TrustedDeviceRepository.LoadAll error: " + ex.Message);
                    return new List<TrustedDevice>();
                }
            }
        }

        public bool Delete(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
                return false;

            lock (_lockObj)
            {
                try
                {
                    List<TrustedDevice> devices = LoadAll();
                    bool removed = devices.RemoveAll(d => d.DeviceId == deviceId) > 0;
                    if (removed)
                        SaveAllInternal(devices);
                    return removed;
                }
                catch (Exception ex)
                {
                    AppLogger.Log("TrustedDeviceRepository.Delete error: " + ex.Message);
                    return false;
                }
            }
        }

        private void SaveAllInternal(List<TrustedDevice> devices)
        {
            string json = SerializeDevices(devices);
            File.WriteAllText(_filePath, json, Encoding.UTF8);
        }

        private string SerializeDevices(List<TrustedDevice> devices)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[");
            for (int i = 0; i < devices.Count; i++)
            {
                sb.Append("  {\"DeviceId\":\"");
                sb.Append(EscapeJson(devices[i].DeviceId));
                sb.Append("\",\"Name\":\"");
                sb.Append(EscapeJson(devices[i].Name));
                sb.Append("\",\"IpAddress\":\"");
                sb.Append(EscapeJson(devices[i].IpAddress ?? ""));
                sb.Append("\",\"ConnectionType\":\"");
                sb.Append(EscapeJson(devices[i].ConnectionType ?? "Ethernet"));
                sb.Append("\",\"PairingToken\":\"");
                sb.Append(EscapeJson(devices[i].PairingToken ?? ""));
                sb.Append("\",\"TrustedSince\":\"");
                sb.Append(devices[i].TrustedSince.ToString("O"));
                sb.Append("\",\"LastUsed\":\"");
                sb.Append(devices[i].LastUsed.ToString("O"));
                sb.Append("\"}");
                if (i < devices.Count - 1)
                    sb.Append(",");
                sb.AppendLine();
            }
            sb.AppendLine("]");
            return sb.ToString();
        }

        private List<TrustedDevice> DeserializeDevices(string json)
        {
            List<TrustedDevice> devices = new List<TrustedDevice>();

            if (StringHelper.IsNullOrWhiteSpace(json))
                return devices;

            json = json.Trim();
            if (!json.StartsWith("[") || !json.EndsWith("]"))
                return devices;

            string content = json.Substring(1, json.Length - 2);
            string[] deviceStrs = content.Split(new string[] { "},{" }, StringSplitOptions.None);

            foreach (string deviceStr in deviceStrs)
            {
                try
                {
                    string cleaned = deviceStr.Replace("{", "").Replace("}", "").Trim();
                    if (StringHelper.IsNullOrWhiteSpace(cleaned))
                        continue;

                    Dictionary<string, string> fields = ParseJsonObject(cleaned);
                    if (fields.ContainsKey("DeviceId"))
                    {
                        DateTime trustedSince = DateTime.UtcNow;
                        if (fields.ContainsKey("TrustedSince"))
                        {
                            DateTime.TryParse(fields["TrustedSince"], out trustedSince);
                        }

                        DateTime lastUsed = DateTime.UtcNow;
                        if (fields.ContainsKey("LastUsed"))
                        {
                            DateTime.TryParse(fields["LastUsed"], out lastUsed);
                        }

                        var device = new TrustedDevice
                        {
                            DeviceId = fields["DeviceId"],
                            Name = fields.ContainsKey("Name") ? fields["Name"] : "",
                            IpAddress = fields.ContainsKey("IpAddress") ? fields["IpAddress"] : "",
                            ConnectionType = fields.ContainsKey("ConnectionType") ? fields["ConnectionType"] : "Ethernet",
                            PairingToken = fields.ContainsKey("PairingToken") ? fields["PairingToken"] : "",
                            TrustedSince = trustedSince,
                            LastUsed = lastUsed
                        };
                        devices.Add(device);
                    }
                }
                catch
                {
                    // skip malformed entries
                }
            }

            return devices;
        }

        private Dictionary<string, string> ParseJsonObject(string obj)
        {
            Dictionary<string, string> result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (string.IsNullOrEmpty(obj))
                return result;

            int i = 0;
            while (i < obj.Length)
            {
                int keyStart = obj.IndexOf('"', i);
                if (keyStart < 0) break;
                int keyEnd = obj.IndexOf('"', keyStart + 1);
                if (keyEnd < 0) break;

                string key = obj.Substring(keyStart + 1, keyEnd - keyStart - 1);
                int colon = obj.IndexOf(':', keyEnd + 1);
                if (colon < 0) break;

                int valStart = colon + 1;
                while (valStart < obj.Length && char.IsWhiteSpace(obj[valStart])) valStart++;
                if (valStart >= obj.Length) break;

                string val = "";
                if (obj[valStart] == '"')
                {
                    int valEnd = valStart + 1;
                    while (valEnd < obj.Length)
                    {
                        if (obj[valEnd] == '"' && obj[valEnd - 1] != '\\')
                            break;
                        valEnd++;
                    }
                    if (valEnd < obj.Length)
                    {
                        val = obj.Substring(valStart + 1, valEnd - valStart - 1);
                        i = valEnd + 1;
                    }
                    else
                    {
                        i = obj.Length;
                    }
                }
                else
                {
                    int comma = obj.IndexOf(',', valStart);
                    if (comma < 0)
                    {
                        val = obj.Substring(valStart).Trim();
                        i = obj.Length;
                    }
                    else
                    {
                        val = obj.Substring(valStart, comma - valStart).Trim();
                        i = comma + 1;
                    }
                }

                result[key] = UnescapeJson(val);
            }

            return result;
        }

        private string EscapeJson(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            return value.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r");
        }

        private string UnescapeJson(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            return value.Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\\"", "\"").Replace("\\\\", "\\");
        }
    }
}
