using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class CommandLineArguments
    {
        public int NumberOfBoxes { get; }
        public string MortyAssemblyPath { get; }
        public string MortyClassName { get; }

        public CommandLineArguments(int numberOfBoxes, string mortyAssemblyPath, string mortyClassName)
        {
            NumberOfBoxes = numberOfBoxes;
            MortyAssemblyPath = mortyAssemblyPath;
            MortyClassName = mortyClassName;
        }

        public void Validate()
        {
            if (NumberOfBoxes < 3) throw new ArgumentException("Number of boxes must be greater than 2");

            if (string.IsNullOrWhiteSpace(MortyAssemblyPath)) throw new ArgumentException("Morty assembly path is required");

            if (!File.Exists(MortyAssemblyPath)) throw new FileNotFoundException($"Morty assembly not found: {MortyAssemblyPath}");
        }
    }
}
