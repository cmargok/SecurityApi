using System.Security.Cryptography;
using System.Text;

namespace RedSecure.Domain.Utils.Encryption
{
    public class Encrypt
    {        
        public static string GenerateSha256Hash(string sal, string input)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(sal + input));
            StringBuilder builder = new();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString()[..32];
        }
    }

}
