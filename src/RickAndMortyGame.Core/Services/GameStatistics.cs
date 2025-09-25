using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Services
{
    public class GameStatistics
    {
        private int _totalGames;
        private int _gamesWon;
        private int _switchGames;
        private int _switchWins;
        private int _stayGames;
        private int _stayWins;

        public int TotalGames
        {
            get { return _totalGames; }
        }
        public int GamesWon
        {
            get { return _gamesWon; }
        }
        public int SwitchGames
        {
            get { return _switchGames; }
        }
        public int SwitchWins
        {
            get { return _switchWins; }
        }
        public int StayGames
        {
            get { return _stayGames; }
        }
        public int StayWins
        {
            get { return _stayWins; }
        }

        public void RecordGame(bool won, bool switched, int numOfBoxes)
        {
            _totalGames++;

            if (won) _gamesWon++;

            if (switched){
                _switchGames++;
                if(won) _switchWins++;
            }
            else
            {
                _stayGames++;
                if (won) _stayWins++;
            }
        }

        public double GetExperimentalWinProbabilityWhenSwitch()
        {
            return _switchGames > 0 ? (double)_switchWins / _switchGames : 0;
        }

        public double GetExperimentalWinProbabilityWhenStay()
        {
            return _stayGames > 0 ? (double)_stayWins / _stayGames : 0;
        }
    }
}
