
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Samsara.Framework.Util
{
    public class CryptoUtil
    {
        /// <summary>
        /// Usually a salted hash of the password is stored and compared. 
        /// If you encrypt/decrypt the password you have the password as plain text again and this is dangerous. 
        /// The hash should be salted to avoid duplicated hash if the some users have the same passwords. For the salt you can take the user name
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Hashed password</returns>
        [DebuggerStepThrough]
        public static string PasswordHash(string username, string password)
        {
            HashAlgorithm hash = new SHA256Managed();

            // compute hash of the password
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = hash.ComputeHash(plainTextBytes);

            // create salted byte array
            byte[] saltBytes = Encoding.UTF8.GetBytes(username.ToLower());
            byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];

            for (int i = 0; i < plainTextBytes.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainTextBytes[i];
            }

            // compute salted hash
            byte[] saltedHashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            return Convert.ToBase64String(saltedHashBytes);
        }
    }
}
