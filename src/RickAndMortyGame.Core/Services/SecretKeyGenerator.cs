using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class SecretKeyGenerator
    {
        public byte[] GenerateKey(int sizeInBytes = 32)
        {
            using var rng = RandomNumberGenerator.Create();
            var key = new byte[sizeInBytes];
            rng.GetBytes(key);

            return key;
        }
    }
}
