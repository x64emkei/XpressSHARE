using System;
using XpressShare.Core;
using XpressShare.Models;
using XpressShare.Security;
using XpressShare.Storage;

namespace XpressShare.Services
{
    public class LocalAccountService
    {
        private readonly UserRepository _repository;

        public LocalAccountService()
        {
            _repository = new UserRepository();
        }

        public bool Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            UserAccount user = _repository.Load(username);
            if (user == null)
                return false;

            return PasswordHasher.VerifyPassword(password, user.PasswordHash);
        }

        public bool Register(string username, string displayName, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            // Check if user already exists
            if (_repository.Load(username) != null)
                return false;

            string passwordHash = PasswordHasher.HashPassword(password);
            var user = new UserAccount
            {
                Username = username,
                DisplayName = string.IsNullOrEmpty(displayName) ? username : displayName,
                PasswordHash = passwordHash
            };

            try
            {
                _repository.Save(user);
                return true;
            }
            catch (Exception ex)
            {
                AppLogger.Log("LocalAccountService.Register error: " + ex.Message);
                return false;
            }
        }

        public UserAccount GetLocalUser(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            return _repository.Load(username);
        }

        public bool UserExists(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            return _repository.Load(username) != null;
        }
    }
}
