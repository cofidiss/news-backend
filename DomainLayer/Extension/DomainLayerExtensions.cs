using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Extension
{
    public static class DomainLayerExtensions
    {

        public static string GetHashAsHEXString(this string inputString)
        {

            var inputStringAsUTFBytes = Encoding.UTF8.GetBytes(inputString);
            var hashedBytes = SHA512.HashData(inputStringAsUTFBytes);

            var hashAsHEXString = string.Join(string.Empty, Array.ConvertAll(hashedBytes, x => x.ToString("X2")));
            return hashAsHEXString;
        }

    }
}
