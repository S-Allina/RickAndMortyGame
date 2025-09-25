using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class CommandLineParser
    {
        public CommandLineArguments Parse(string[] args)
        {
            try
            {
                if (args.Length < 3)
                {
                    throw new ArgumentException(
                    "Not enough arguments provided.\n" +
                    "Usage: RickAndMortyGame.Cli <numberOfBoxes> <mortyAssemblyPath> <mortyClassName>\n" +
                    "Example: RickAndMortyGame.Cli 5 \"./path with spaces/Morty.dll\" \"MyMorty\"");
                }

                if (!int.TryParse(args[0], out int count) || count < 3)
                {
                    throw new ArgumentException(
                    $"Invalid number of boxes: '{args[0]}'. Must be an integer greater than 2.\n" +
                    "Example: 3, 5, 10");
                }

                string assemblyPath = args[1].Trim('"');
                string className = args[2].Trim('"');

                if (!IsBuiltMorty(className)) throw new ArgumentException("There is no Morty with that name.");

                var argum = new CommandLineArguments(count, assemblyPath, className);

                argum.Validate();

                return argum;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                $"Error parsing command line arguments: {ex.Message}\n" +
                "Usage: <numberOfBoxes> <mortyAssemblyPath> <mortyClassName>",
                ex);
            }
        }

        private bool IsBuiltMorty(string nameMorty) 
        {
            var buitInMorties = new[] { "classicmorty", "lazymorty", "cunningmorty" };

            return buitInMorties.Contains(nameMorty.ToLower());
        }
    }
}
