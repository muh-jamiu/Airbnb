using System;
using System.Security.Cryptography;

namespace Users.models
{
    public class PasswordHasher
    {
        private const int SaltSize = 32; // Size of the salt in bytes
        private const int HashSize = 32; // Size of the hash in bytes
        private const int Iterations = 10000; // Number of iterations for the hash function

        public static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);
            byte[] expectedHash = new byte[HashSize];
            Array.Copy(hashBytes, SaltSize, expectedHash, 0, HashSize);

            // Compute the hash of the provided password
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] actualHash = pbkdf2.GetBytes(HashSize);

            // Compare the computed hash with the expected hash
            for (int i = 0; i < HashSize; i++)
            {
                if (actualHash[i] != expectedHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

}