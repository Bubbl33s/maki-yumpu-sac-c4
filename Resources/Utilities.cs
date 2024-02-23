using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace MakiYumpuSAC.Resources
{
    public class Utilities
    {
        public static string EncryptKey(string key)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(key));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }

            return sb.ToString();
        }

        public static SelectList HebrasOptions()
        {
            var hebras = new List<string>
            {
                "1/5",
                "2/16",
                "2/28",
                "2/32",
                "3/10"
            };

            return new SelectList(hebras);
        }
    }
}
