using System.Security.Cryptography;
using System.Text;

namespace WSVentaAPI.Tools
{
    public class Encrypt
    {
        public static string GetSHA256(string str)
        {
            SHA256 sh256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder stringBuilder = new StringBuilder();
            stream = sh256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; ++i) stringBuilder.AppendFormat("{0:x2}", stream[i]);

            return stringBuilder.ToString();
        }
    }
}
