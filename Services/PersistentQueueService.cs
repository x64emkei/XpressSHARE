using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XpressShare.Core;
using XpressShare.Models;

namespace XpressShare.Services
{
    public class PersistentQueueService
    {
        private readonly string _queueFilePath;
        private readonly object _lockObj = new object();

        public PersistentQueueService()
        {
            _queueFilePath = Path.Combine(AppPaths.BasePath, "transfer.queue");
        }

        public void SaveQueue(IEnumerable<TransferItem> items)
        {
            if (items == null)
                return;

            lock (_lockObj)
            {
                string tempFilePath = _queueFilePath + ".tmp." + Guid.NewGuid().ToString("N");
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("[");
                    bool first = true;
                    foreach (TransferItem item in items)
                    {
                        if (item == null)
                            continue;

                        if (!first)
                            sb.AppendLine(",");
                        first = false;

                        sb.Append("  {");
                        sb.Append("\"Id\":\"").Append(EscapeJson(item.Id)).Append("\",");
                        sb.Append("\"RemoteDeviceId\":\"").Append(EscapeJson(item.RemoteDeviceId)).Append("\",");
                        sb.Append("\"RemoteDeviceName\":\"").Append(EscapeJson(item.RemoteDeviceName)).Append("\",");
                        sb.Append("\"RemoteIpAddress\":\"").Append(EscapeJson(item.RemoteIpAddress)).Append("\",");
                        sb.Append("\"RemotePort\":").Append(item.RemotePort).Append(",");
                        sb.Append("\"FilePath\":\"").Append(EscapeJson(item.FilePath)).Append("\",");
                        sb.Append("\"TotalBytes\":").Append(item.TotalBytes).Append(",");
                        sb.Append("\"TransferredBytes\":").Append(item.TransferredBytes).Append(",");
                        sb.Append("\"Status\":").Append((int)item.Status).Append(",");
                        sb.Append("\"Direction\":").Append((int)item.Direction).Append(",");
                        sb.Append("\"CreatedTime\":\"").Append(item.CreatedTime.ToString("O")).Append("\"");
                        sb.Append("}");
                    }
                    if (!first)
                        sb.AppendLine();
                    sb.AppendLine("]");

                    File.WriteAllText(tempFilePath, sb.ToString(), Encoding.UTF8);

                    // Atomic replace: if target exists, replace or overwrite
                    if (File.Exists(_queueFilePath))
                    {
                        File.Delete(_queueFilePath);
                    }
                    File.Move(tempFilePath, _queueFilePath);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("PersistentQueueService.SaveQueue error: " + ex.Message);
                    try
                    {
                        if (File.Exists(tempFilePath))
                            File.Delete(tempFilePath);
                    }
                    catch
                    {
                    }
                }
            }
        }

        public List<TransferItem> LoadQueue()
        {
            lock (_lockObj)
            {
                List<TransferItem> list = new List<TransferItem>();
                if (!File.Exists(_queueFilePath))
                    return list;

                try
                {
                    string content = File.ReadAllText(_queueFilePath, Encoding.UTF8);
                    if (string.IsNullOrEmpty(content))
                        return list;

                    content = content.Trim();
                    if (!content.StartsWith("[") || !content.EndsWith("]"))
                        return list;

                    string inner = content.Substring(1, content.Length - 2).Trim();
                    if (string.IsNullOrEmpty(inner))
                        return list;

                    string[] entries = inner.Split(new string[] { "}," }, StringSplitOptions.None);
                    for (int i = 0; i < entries.Length; i++)
                    {
                        string entry = entries[i].Trim();
                        if (entry.StartsWith("{"))
                            entry = entry.Substring(1);
                        if (entry.EndsWith("}"))
                            entry = entry.Substring(0, entry.Length - 1);

                        entry = entry.Trim();
                        if (string.IsNullOrEmpty(entry))
                            continue;

                        Dictionary<string, string> fields = ParseJsonProperties(entry);
                        TransferItem item = new TransferItem();

                        if (fields.ContainsKey("Id")) item.Id = fields["Id"];
                        if (fields.ContainsKey("RemoteDeviceId")) item.RemoteDeviceId = fields["RemoteDeviceId"];
                        if (fields.ContainsKey("RemoteDeviceName")) item.RemoteDeviceName = fields["RemoteDeviceName"];
                        if (fields.ContainsKey("RemoteIpAddress")) item.RemoteIpAddress = fields["RemoteIpAddress"];
                        if (fields.ContainsKey("RemotePort"))
                        {
                            int port;
                            if (int.TryParse(fields["RemotePort"], out port))
                                item.RemotePort = port;
                        }
                        if (fields.ContainsKey("FilePath")) item.FilePath = fields["FilePath"];
                        if (fields.ContainsKey("TotalBytes"))
                        {
                            long total;
                            if (long.TryParse(fields["TotalBytes"], out total))
                                item.TotalBytes = total;
                        }
                        if (fields.ContainsKey("TransferredBytes"))
                        {
                            long trans;
                            if (long.TryParse(fields["TransferredBytes"], out trans))
                                item.TransferredBytes = trans;
                        }
                        if (fields.ContainsKey("Status"))
                        {
                            int status;
                            if (int.TryParse(fields["Status"], out status))
                                item.Status = (TransferStatus)status;
                        }
                        if (fields.ContainsKey("Direction"))
                        {
                            int dir;
                            if (int.TryParse(fields["Direction"], out dir))
                                item.Direction = (TransferDirection)dir;
                        }
                        if (fields.ContainsKey("CreatedTime"))
                        {
                            DateTime dt;
                            if (DateTime.TryParse(fields["CreatedTime"], out dt))
                                item.CreatedTime = dt;
                        }

                        list.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.Log("PersistentQueueService.LoadQueue error: " + ex.Message);
                }

                return list;
            }
        }

        private Dictionary<string, string> ParseJsonProperties(string raw)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string[] pairs = raw.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < pairs.Length; i++)
            {
                string pair = pairs[i].Trim();
                int colonIdx = pair.IndexOf(':');
                if (colonIdx <= 0)
                    continue;

                string key = pair.Substring(0, colonIdx).Trim().Trim('"');
                string val = pair.Substring(colonIdx + 1).Trim();
                if (val.StartsWith("\"") && val.EndsWith("\"") && val.Length >= 2)
                {
                    val = val.Substring(1, val.Length - 2);
                }
                dict[key] = UnescapeJson(val);
            }
            return dict;
        }

        private string EscapeJson(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            return value.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r");
        }

        private string UnescapeJson(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            return value.Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\\"", "\"").Replace("\\\\", "\\");
        }
    }
}
