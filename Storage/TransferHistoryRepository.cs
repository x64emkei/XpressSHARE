using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XpressShare.Core;

namespace XpressShare.Storage
{
    public class TransferHistoryRepository
    {
        private readonly string _filePath;
        private readonly object _lockObj = new object();

        public class TransferHistoryEntry
        {
            public DateTime Timestamp { get; set; }
            public string RemoteDeviceId { get; set; }
            public string RemoteDeviceName { get; set; }
            public string FilePath { get; set; }
            public long FileSize { get; set; }
            public bool Success { get; set; }
            public bool IsUpload { get; set; }
        }

        public TransferHistoryRepository()
        {
            _filePath = Path.Combine(AppPaths.BasePath, "history.json");
        }

        public void RecordTransfer(string remoteDeviceId, string remoteDeviceName, string filePath, long fileSize, bool success, bool isUpload)
        {
            lock (_lockObj)
            {
                try
                {
                    var entry = new TransferHistoryEntry
                    {
                        Timestamp = DateTime.UtcNow,
                        RemoteDeviceId = remoteDeviceId,
                        RemoteDeviceName = remoteDeviceName,
                        FilePath = filePath,
                        FileSize = fileSize,
                        Success = success,
                        IsUpload = isUpload
                    };

                    AppendEntry(entry);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("TransferHistoryRepository.RecordTransfer error: " + ex.Message);
                }
            }
        }

        public List<TransferHistoryEntry> GetHistory()
        {
            lock (_lockObj)
            {
                try
                {
                    if (!File.Exists(_filePath))
                        return new List<TransferHistoryEntry>();

                    string json = File.ReadAllText(_filePath, Encoding.UTF8);
                    return DeserializeHistory(json);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("TransferHistoryRepository.GetHistory error: " + ex.Message);
                    return new List<TransferHistoryEntry>();
                }
            }
        }

        public List<TransferHistoryEntry> GetHistoryAfter(DateTime date)
        {
            lock (_lockObj)
            {
                var all = GetHistory();
                List<TransferHistoryEntry> result = new List<TransferHistoryEntry>();
                foreach (var entry in all)
                {
                    if (entry.Timestamp > date)
                        result.Add(entry);
                }
                return result;
            }
        }

        public void ClearHistory()
        {
            lock (_lockObj)
            {
                try
                {
                    SaveEntries(new List<TransferHistoryEntry>());
                }
                catch (Exception ex)
                {
                    AppLogger.Log("TransferHistoryRepository.ClearHistory error: " + ex.Message);
                }
            }
        }

        private void AppendEntry(TransferHistoryEntry entry)
        {
            List<TransferHistoryEntry> entries = new List<TransferHistoryEntry>();

            if (File.Exists(_filePath))
            {
                string existing = File.ReadAllText(_filePath, Encoding.UTF8);
                entries = DeserializeHistory(existing);
            }

            entries.Add(entry);
            SaveEntries(entries);
        }

        private void SaveEntries(List<TransferHistoryEntry> entries)
        {
            string json = SerializeHistory(entries);
            File.WriteAllText(_filePath, json, Encoding.UTF8);
        }

        private string SerializeHistory(List<TransferHistoryEntry> entries)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[");
            for (int i = 0; i < entries.Count; i++)
            {
                sb.Append("  {\"Timestamp\":\"");
                sb.Append(entries[i].Timestamp.ToString("O"));
                sb.Append("\",\"RemoteDeviceId\":\"");
                sb.Append(EscapeJson(entries[i].RemoteDeviceId));
                sb.Append("\",\"RemoteDeviceName\":\"");
                sb.Append(EscapeJson(entries[i].RemoteDeviceName));
                sb.Append("\",\"FilePath\":\"");
                sb.Append(EscapeJson(entries[i].FilePath));
                sb.Append("\",\"FileSize\":");
                sb.Append(entries[i].FileSize);
                sb.Append(",\"Success\":");
                sb.Append(entries[i].Success ? "true" : "false");
                sb.Append(",\"IsUpload\":");
                sb.Append(entries[i].IsUpload ? "true" : "false");
                sb.Append("}");
                if (i < entries.Count - 1)
                    sb.Append(",");
                sb.AppendLine();
            }
            sb.AppendLine("]");
            return sb.ToString();
        }

        private List<TransferHistoryEntry> DeserializeHistory(string json)
        {
            List<TransferHistoryEntry> entries = new List<TransferHistoryEntry>();

            if (StringHelper.IsNullOrWhiteSpace(json))
                return entries;

            json = json.Trim();
            if (!json.StartsWith("[") || !json.EndsWith("]"))
                return entries;

            string content = json.Substring(1, json.Length - 2);
            string[] entryStrs = content.Split(new string[] { "},{" }, StringSplitOptions.None);

            foreach (string entryStr in entryStrs)
            {
                try
                {
                    string cleaned = entryStr.Replace("{", "").Replace("}", "").Trim();
                    if (StringHelper.IsNullOrWhiteSpace(cleaned))
                        continue;

                    Dictionary<string, string> fields = ParseJsonObject(cleaned);

                    DateTime timestamp = DateTime.UtcNow;
                    if (fields.ContainsKey("Timestamp"))
                        DateTime.TryParse(fields["Timestamp"], out timestamp);

                    long fileSize = 0;
                    if (fields.ContainsKey("FileSize"))
                        long.TryParse(fields["FileSize"], out fileSize);

                    bool success = fields.ContainsKey("Success") && fields["Success"].ToLower() == "true";
                    bool isUpload = fields.ContainsKey("IsUpload") && fields["IsUpload"].ToLower() == "true";

                    var entry = new TransferHistoryEntry
                    {
                        Timestamp = timestamp,
                        RemoteDeviceId = fields.ContainsKey("RemoteDeviceId") ? fields["RemoteDeviceId"] : "",
                        RemoteDeviceName = fields.ContainsKey("RemoteDeviceName") ? fields["RemoteDeviceName"] : "",
                        FilePath = fields.ContainsKey("FilePath") ? fields["FilePath"] : "",
                        FileSize = fileSize,
                        Success = success,
                        IsUpload = isUpload
                    };

                    entries.Add(entry);
                }
                catch
                {
                    // skip malformed entries
                }
            }

            return entries;
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
