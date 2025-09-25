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

        Task<int> HidePortalGunAsync(int numberOfBoxes, IRandomProvider randomProvider);
        Task<int> DecideWhichBoxToSaveAsync(int[] boxes, int portalGunBox, IRandomProvider randomProvider);

        double CalculateWinProbablyWhenSwich(int numOfBoxes);
        double CalculateWinProbablyWhenStay(int numOfBoxes);
    }
}
