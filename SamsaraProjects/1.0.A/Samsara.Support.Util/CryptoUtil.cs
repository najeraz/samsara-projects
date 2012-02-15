
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Samsara.Support.Util
{
    public class CryptoUtil
    {
        [DebuggerStepThrough]
        public static string MD5Hash(string value)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();

            byte[] data = Encoding.ASCII.GetBytes(value);
            data = provider.ComputeHash(data);

            string md5 = string.Empty;

            foreach (byte byteValue in data)
                md5 += byteValue.ToString("x2").ToLower();

            return md5;
        }
    }
}
