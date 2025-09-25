using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class ComputerRandomGenerator
    {
        public int GenerateComputerValue(int maxValue)
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[4];
            rng.GetBytes(bytes);
            var number = BitConverter.ToInt32(bytes, 0) & int.MaxValue;

            return number % maxValue;
        }
    }
}
