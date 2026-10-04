using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XpressShare.Core;
using XpressShare.Models;

namespace XpressShare.Storage
{
    public class UserRepository
    {
        private readonly string _filePath;
        private readonly object _lockObj = new object();

        public UserRepository()
        {
            _filePath = Path.Combine(AppPaths.BasePath, "users.json");
        }

        public void Save(UserAccount user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            lock (_lockObj)
            {
                try
                {
                    List<UserAccount> users = LoadAll();
                    int index = users.FindIndex(u => u.Username == user.Username);
                    if (index >= 0)
                        users[index] = user;
                    else
                        users.Add(user);

                    SaveAllInternal(users);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("UserRepository.Save error: " + ex.Message);
                    throw;
                }
            }
        }

        public UserAccount Load(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            lock (_lockObj)
            {
                try
                {
                    List<UserAccount> users = LoadAll();
                    return users.Find(u => u.Username == username);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("UserRepository.Load error: " + ex.Message);
                    return null;
                }
            }
        }

        public List<UserAccount> LoadAll()
        {
            lock (_lockObj)
            {
                try
                {
                    if (!File.Exists(_filePath))
                        return new List<UserAccount>();

                    string json = File.ReadAllText(_filePath, Encoding.UTF8);
                    return DeserializeUsers(json);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("UserRepository.LoadAll error: " + ex.Message);
                    return new List<UserAccount>();
                }
            }
        }

        public bool Delete(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            lock (_lockObj)
            {
                try
                {
                    List<UserAccount> users = LoadAll();
                    bool removed = users.RemoveAll(u => u.Username == username) > 0;
                    if (removed)
                        SaveAllInternal(users);
                    return removed;
                }
                catch (Exception ex)
                {
                    AppLogger.Log("UserRepository.Delete error: " + ex.Message);
                    return false;
                }
            }
        }

        private void SaveAllInternal(List<UserAccount> users)
        {
            string json = SerializeUsers(users);
            File.WriteAllText(_filePath, json, Encoding.UTF8);
        }

        private string SerializeUsers(List<UserAccount> users)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[");
            for (int i = 0; i < users.Count; i++)
            {
                sb.Append("  {\"Username\":\"");
                sb.Append(EscapeJson(users[i].Username));
                sb.Append("\",\"DisplayName\":\"");
                sb.Append(EscapeJson(users[i].DisplayName));
                sb.Append("\",\"PasswordHash\":\"");
                sb.Append(EscapeJson(users[i].PasswordHash));
                sb.Append("\"}");
                if (i < users.Count - 1)
                    sb.Append(",");
                sb.AppendLine();
            }
            sb.AppendLine("]");
            return sb.ToString();
        }

        private List<UserAccount> DeserializeUsers(string json)
        {
            List<UserAccount> users = new List<UserAccount>();

            if (StringHelper.IsNullOrWhiteSpace(json))
                return users;

            json = json.Trim();
            if (!json.StartsWith("[") || !json.EndsWith("]"))
                return users;

            string content = json.Substring(1, json.Length - 2);
            string[] userStrs = content.Split(new string[] { "},{" }, StringSplitOptions.None);

            foreach (string userStr in userStrs)
            {
                try
                {
                    string cleaned = userStr.Replace("{", "").Replace("}", "").Trim();
                    if (StringHelper.IsNullOrWhiteSpace(cleaned))
                        continue;

                    Dictionary<string, string> fields = ParseJsonObject(cleaned);
                    if (fields.ContainsKey("Username"))
                    {
                        var user = new UserAccount
                        {
                            Username = fields["Username"],
                            DisplayName = fields.ContainsKey("DisplayName") ? fields["DisplayName"] : "",
                            PasswordHash = fields.ContainsKey("PasswordHash") ? fields["PasswordHash"] : ""
                        };
                        users.Add(user);
                    }
                }
                catch
                {
                    // skip malformed entries
                }
            }

            return users;
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
