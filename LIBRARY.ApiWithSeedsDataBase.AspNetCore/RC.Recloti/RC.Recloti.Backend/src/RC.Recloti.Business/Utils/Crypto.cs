using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RC.Recloti.Business.Utils
{
    public static class Crypto
    {
        public static string CryptoSHA1(string pass)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(pass));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
    }
}
