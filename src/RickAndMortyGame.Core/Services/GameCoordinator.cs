using RickAndMortyGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class GameCoordinator
    {
        private readonly CommandLineParser _parser;
        private readonly MortyLoader _mortyLoader;

        public GameCoordinator()
        {
            _parser = new CommandLineParser();
            _mortyLoader = new MortyLoader();
        }

        public async Task StartGameAsync(string[] args)
        {
            try
            {
                var config = _parser.Parse(args);

                var morty = _mortyLoader.LoadMorty(config.MortyAssemblyPath, config.MortyClassName);
                var randomProvider = new CryptographicRandomProvider();
                var statistics = new GameStatistics();
                var gameEngine = new GameEngine(morty, randomProvider, statistics);
                var render = new GameRenderer();
                var startsPresenter = new StatisticsPresenter();

                render.ShowWelcomeMessage(morty.Name);

                int round = 1;
                bool playAgain = true;

                while (playAgain)
                {
                    render.ShowRoundStart(round, config.NumberOfBoxes);

                    var result = await gameEngine.PlayRoundAsync(config.NumberOfBoxes);

                    render.ShowGameResult(result);

                    playAgain = render.AskForAnotherRound();

                    round++;
                }

                startsPresenter.ShowStatistics(statistics, morty, config.NumberOfBoxes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Usage: RickAndMortyGame.Cli <numberOfBoxes> <mortyAssemblyPath> <mortyClassName>");
                Console.WriteLine("Example: RickAndMortyGame.Cli 3 ./ClassicMorty.dll ClassicMorty");
                Environment.Exit(1);
            }
        }
    }
}
