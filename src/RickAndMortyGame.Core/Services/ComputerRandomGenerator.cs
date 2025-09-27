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
            return RandomNumberGenerator.GetInt32(0, maxValue);
        }
    }
}
