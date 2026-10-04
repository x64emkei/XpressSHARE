using System;

namespace XpressShare.Models
{
    public class UserAccount
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string PasswordHash { get; set; }
    }
}
