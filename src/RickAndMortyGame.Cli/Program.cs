using RickAndMortyGame.Core.Services;

namespace RickAndMortyGame.Cli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var coordinator = new GameCoordinator();

                coordinator.StartGameAsync(args).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oh geez, Rick! Something went wrong: {ex.Message}");
                Console.WriteLine("Maybe we should, like, check the arguments?");

                Environment.Exit(1);
            }
        }
    }
}
