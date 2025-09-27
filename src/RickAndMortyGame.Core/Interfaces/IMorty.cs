using RickAndMortyGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Interfaces
{
    public interface IMorty
    {
        string Name { get; }

        int HidePortalGun(int numberOfBoxes, IRandomProvider randomProvider);
        int DecideWhichBoxToSave(int[] boxes, int portalGunBox, FairRandomResult secondRoundResult);

        double CalculateWinProbablyWhenSwich(int numOfBoxes);
        double CalculateWinProbablyWhenStay(int numOfBoxes);
    }
}
