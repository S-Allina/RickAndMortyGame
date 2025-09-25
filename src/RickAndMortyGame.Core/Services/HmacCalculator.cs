using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class HmacCalculator
    {
        public string CalculateHmac(int value, byte[] key)
        {
            using var hmac = new HMACSHA256(key);
            var valueBytes = BitConverter.GetBytes(value);
            var hash = hmac.ComputeHash(valueBytes);
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
