using RickAndMortyGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class MortyLoader
    {
        public IMorty LoadMorty(string path, string name)
        {
            try
            {
                var assembly = Assembly.LoadFrom(path);
                var type = assembly.GetType($"{name}.{name}");

                return (IMorty)Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                $"Failed to load Morty from {path}: {ex.Message}. Make sure the assembly exists and the class implements IMorty interface.",
                ex);
            }
        }
    }
}
