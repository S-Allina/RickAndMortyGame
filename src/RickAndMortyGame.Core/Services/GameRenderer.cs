using RickAndMortyGame.Core.Interfaces;
using RickAndMortyGame.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class GameRenderer
    {
        public void ShowWelcomeMessage(string mortyName)
        {
            Console.WriteLine($"Morty: Oh, Rick! I'm {mortyName} and I'm ready to play!");
            Console.WriteLine($"Morty: We're gonna hide your portal gun and see if you can find it!");
            Console.WriteLine("");
        }

        public void ShowRoundStart(int roundNum, int totalBoxes)
        {
            Console.WriteLine($"=== ROUND {roundNum} ===");
            Console.WriteLine($"Morty: Okay, Rick! {totalBoxes} boxes this time!");
            Console.WriteLine("");
        }

        public void ShowGameResult(GameRoundResult result)
        {
            if (result.Won)
            {
                Console.WriteLine($"Morty: AWW MAN! You found the portal gun in box {result.PortalGunBox}!");
                Console.WriteLine($"Morty: Aww man, you win, Rick. I guess we're going on one of YOUR crazy adventures..");
            }
            else
            {
                Console.WriteLine($"Morty: HEH HEH! The portal gun was in box {result.PortalGunBox}!");
                Console.WriteLine($"Morty: Aww man, you lost, Rick. Now we gotta go on one of MY boring adventures!");
            }
        }

        public bool AskForAnotherRound()
        {
            Console.WriteLine("Morty: D-do you wanna play another round? (y/n)");

            while (true)
            {
                var response = (Console.ReadLine())?.ToLower();

                switch (response)
                {
                    case "y":
                    case "yes":
                        Console.WriteLine("Morty: Okay! Let's go again!");
                        return true;
                    case "n":
                    case "no":
                        Console.WriteLine("Morty: Okay, buy!");
                        return false;
                    default:
                        Console.WriteLine("Morty: Oh geez, Rick! Just say 'y' for yes or 'n' for no!");
                        break;
                }
            }
        }
    }
}
