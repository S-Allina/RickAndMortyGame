using ConsoleTables;
using RickAndMortyGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class StatisticsPresenter
    {
        public void ShowStatistics(GameStatistics statistics, IMorty morty, int numOfBoxes)
        {
            var table = new ConsoleTable("Game results", "Rick switched", "Rick stayed");

            table.AddRow("Rounds", statistics.SwitchGames, statistics.StayGames);
            table.AddRow("Wins", statistics.SwitchWins, statistics.StayWins);
            table.AddRow("p (estimate)", statistics.GetExperimentalWinProbabilityWhenSwitch(), statistics.GetExperimentalWinProbabilityWhenStay());
            table.AddRow("p (exact)", morty.CalculateWinProbablyWhenSwich(numOfBoxes).ToString("F3"), morty.CalculateWinProbablyWhenStay(numOfBoxes).ToString("F3"));

            Console.WriteLine("===STATISTICS===");
            table.Write(Format.Alternative);
        }
    }
}
