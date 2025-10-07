using System.Security.Cryptography;
using System.Text;

namespace LoanManagementSystem.API.utility
{
    public static class PasswordHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using var hmac = new HMACSHA512(storedSalt);
            var computed = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            if (computed.Length != storedHash.Length) return false;
            for (int i = 0; i < computed.Length; i++)
                if (computed[i] != storedHash[i]) return false;
            return true;
        }
    }
}
