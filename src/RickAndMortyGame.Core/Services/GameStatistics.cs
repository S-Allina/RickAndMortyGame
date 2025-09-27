using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class GameStatistics
    {
        public int TotalGames { get; private set; }
        public int GamesWon { get; private set; }
        public int SwitchGames { get; private set; }
        public int SwitchWins { get; private set; }
        public int StayGames { get; private set; }
        public int StayWins { get; private set; }

        public void RecordGame(bool won, bool switched, int numOfBoxes)
        {
            TotalGames++;

            if (won) GamesWon++;

            if (switched){
                SwitchGames++;
                if(won) SwitchWins++;
            }
            else
            {
                StayGames++;
                if (won) StayWins++;
            }
        }

        public string GetExperimentalWinProbabilityWhenSwitch()
        {
            return SwitchGames > 0 ? (SwitchWins == 0 ? "-" : ((double)SwitchWins / SwitchGames).ToString("F3")) : "0";
        }

        public string GetExperimentalWinProbabilityWhenStay()
        {
            return StayGames > 0 ? (StayWins == 0 ? "-" : ((double)StayWins / StayGames).ToString("F3")) : "0";
        }
    }
}
