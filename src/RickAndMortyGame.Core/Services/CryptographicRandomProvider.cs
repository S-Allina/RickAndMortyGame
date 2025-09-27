using RickAndMortyGame.Core.Interfaces;
using RickAndMortyGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class CryptographicRandomProvider : IRandomProvider
    {
        private readonly SecretKeyGenerator _secretKeyGenerator;
        private readonly ComputerRandomGenerator _randomGenerator;
        private readonly HmacCalculator _hmacCalculator;

        public CryptographicRandomProvider()
        {
            _secretKeyGenerator = new SecretKeyGenerator();
            _randomGenerator = new ComputerRandomGenerator();
            _hmacCalculator = new HmacCalculator(); 
        }

        public FairRandomResult GenerateFairRandom(int maxValue)
        {
            var secretKey = _secretKeyGenerator.GenerateKey();
            var computerValue = _randomGenerator.GenerateComputerValue(maxValue);
            var hmac = _hmacCalculator.CalculateHmac(computerValue, secretKey);

            Console.WriteLine($"Morty: HAMC={hmac}");
            Console.WriteLine($"Morty: Rick, enter your number [0, {maxValue}) and, uh, don’t say I didn’t play fair, okay?");

            var userValue = GetUserInput(maxValue);

            var finalValue = (computerValue + userValue) % (maxValue-1);

            return new FairRandomResult
            {
                ComputerValue = computerValue,
                UserValue = userValue,
                SecretKey = secretKey,
                FinalValue = finalValue,
                Hmac = hmac
            };
        }

        private int GetUserInput(int maxValue)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int num) && num >= 0 && num <= maxValue)
                {
                    return num;
                }
                Console.WriteLine($"Morty: Oh, Rick, enter a number between 0 and {maxValue - 1}, okay?");
            }
        }
    }
}
