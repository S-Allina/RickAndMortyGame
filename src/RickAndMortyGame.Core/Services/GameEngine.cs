using RickAndMortyGame.Core.Interfaces;
using RickAndMortyGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class GameEngine
    {
        private readonly IMorty _morty;
        private readonly IRandomProvider _randomProvider;
        private readonly GameStatistics _gameState;

        public GameEngine(IMorty morty, IRandomProvider randomProvider, GameStatistics statistics)
        {
            _morty = morty;
            _randomProvider = randomProvider;
            _gameState = statistics;
        }

        public GameRoundResult PlayRound(int numOfBoxes)
        {
            Console.WriteLine($"Oh, Rick, I`m gonna hide your portal gun in one of the {numOfBoxes} boxes, okay?");

            var portalGunRes = _randomProvider.GenerateFairRandomAsync(numOfBoxes);
            var portalGunBox = portalGunRes.FinalValue;

            Console.WriteLine($"Morty: Ok, ok, I hid the gun. What's your guess [0,{numOfBoxes})?");
            
            var userGuess =  GetUserInput(numOfBoxes);
            var remainingBoxes = Enumerable.Range(0, numOfBoxes).Where(b => b != userGuess).ToArray();
            var secondRandomResult = PerformSecondFairRandom(remainingBoxes, userGuess);

            var boxToKeep = _morty.DecideWhichBoxToSave(remainingBoxes, portalGunBox, secondRandomResult);
            var finalChoice = GetSwitchDecision(userGuess, [ userGuess, boxToKeep ]);

            RevealFairRandomProof(portalGunRes, secondRandomResult, portalGunBox, numOfBoxes);

            var won = finalChoice == portalGunBox;

            _gameState.RecordGame(won, userGuess != finalChoice, numOfBoxes);

            return new GameRoundResult { Won = won, PortalGunBox = portalGunBox };
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

        private void RevealFairRandomProof(FairRandomResult firstResult, FairRandomResult secondResult, int portalGunBox, int numOfBoxes)
        {
            Console.WriteLine($"Morty: Aww man, my 1st random value is {firstResult.ComputerValue}.");

            Console.WriteLine($"Morty: KEY1={BitConverter.ToString(firstResult.SecretKey).Replace("-", "")}");

            Console.WriteLine($"Morty: So the 1st fair number is ({firstResult.UserValue} + {firstResult.ComputerValue}) % {numOfBoxes} = {firstResult.FinalValue}.");

            Console.WriteLine($"Morty: Aww man, my 2nd random value is {secondResult.ComputerValue}.");

            Console.WriteLine($"Morty: KEY2={BitConverter.ToString(secondResult.SecretKey).Replace("-", "")}");

            Console.WriteLine($"Morty: Uh, okay, the 2nd fair number is ({secondResult.UserValue} + {secondResult.ComputerValue}) % {numOfBoxes-1} = {secondResult.FinalValue}.");

            Console.WriteLine($"Morty: Your portal gun is in the box {portalGunBox}.");
        }

        private int GetSwitchDecision(int userGuess, int[] boxes)
        {
            if (boxes.Length <= 1) return userGuess;

            var otherBox = boxes.First(b => b != userGuess);

            Console.WriteLine($"Morty: I'm keeping the box you chose, I mean {userGuess}, and the box {otherBox}.");
            Console.WriteLine($"Morty: You can switch your box (enter 0), or, you know, stick with it (enter 1).");

            while (true)
            {
                var input = Console.ReadLine()?.Trim();
                switch (input)
                {
                    case "0":
                        Console.WriteLine($"Morty: Okay, you're switching to box {otherBox}.");
                        return otherBox;
                    case "1":
                        Console.WriteLine($"Morty: Staying with box {userGuess}, huh? Bold move...");
                        return userGuess;
                    default:
                        Console.WriteLine($"Morty: Ok, Rick, justenter 0 to switch or 1 to stay, okay?");
                        break;
                }
            }
        }

        private FairRandomResult PerformSecondFairRandom(int[] availableBoxes, int userGuess)
        {
            Console.WriteLine($"Morty: Let's, uh, generate another value now, I mean, to select a box to keep in the game.");

            var secondRandomRes = _randomProvider.GenerateFairRandomAsync(availableBoxes.Length);
            var selectedBox = availableBoxes[secondRandomRes.FinalValue];

            Console.WriteLine($"Morty: So, I'll keep box {selectedBox} in the game...");

            return secondRandomRes;
        }
    }
}
