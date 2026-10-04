using System;
using System.Security.Cryptography;
using System.Text;

namespace XpressShare.Security
{
    public static class PasswordHasher
    {
        private const int SaltLength = 16;
        private const int HashLength = 20;
        private const int Iterations = 10000;

        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be null or empty");

            byte[] salt = new byte[SaltLength];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(salt);

            byte[] hash = DeriveKey(password, salt, Iterations, HashLength);
            byte[] hashWithSalt = new byte[SaltLength + HashLength];
            Array.Copy(salt, 0, hashWithSalt, 0, SaltLength);
            Array.Copy(hash, 0, hashWithSalt, SaltLength, HashLength);

            return Convert.ToBase64String(hashWithSalt);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hash))
                return false;

            byte[] hashWithSalt;
            try
            {
                hashWithSalt = Convert.FromBase64String(hash);
            }
            catch
            {
                return false;
            }

            if (hashWithSalt.Length < SaltLength + HashLength)
                return false;

            byte[] salt = new byte[SaltLength];
            Array.Copy(hashWithSalt, 0, salt, 0, SaltLength);

            byte[] storedHash = new byte[HashLength];
            Array.Copy(hashWithSalt, SaltLength, storedHash, 0, HashLength);

            byte[] computedHash = DeriveKey(password, salt, Iterations, HashLength);

            return ConstantTimeEquals(storedHash, computedHash);
        }

        private static byte[] DeriveKey(string password, byte[] salt, int iterations, int length)
        {
            using (var hmac = new HMACSHA1(salt))
            {
                byte[] data = Encoding.UTF8.GetBytes(password);
                byte[] result = hmac.ComputeHash(data);

                for (int i = 1; i < iterations; i++)
                {
                    result = hmac.ComputeHash(result);
                }

                return result;
            }
        }

        private static bool ConstantTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }

            return result == 0;
        }
    }
}
