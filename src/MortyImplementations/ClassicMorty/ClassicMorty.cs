using RickAndMortyGame.Core.Interfaces;
using RickAndMortyGame.Core.Models;

namespace ClassicMorty
{
    public class ClassicMorty : IMorty
    {
        public string Name => "ClassicMorty";

        public double CalculateWinProbablyWhenStay(int numOfBoxes)
        {
            return 1.0 / numOfBoxes;
        }

        public double CalculateWinProbablyWhenSwich(int numOfBoxes)
        {
            var VALUE_50_PERCENT = 0.5;
            var MIN_QUANTIRY_BOX = 3;

            if (numOfBoxes < MIN_QUANTIRY_BOX)
            {
                return VALUE_50_PERCENT;
            }

            return (double)(numOfBoxes - 1) / numOfBoxes;
        }

        public int DecideWhichBoxToSave(int[] boxes, int portalGunBox, FairRandomResult secondRoundResult)
        {
            if (boxes.Contains(portalGunBox))
            {
                return portalGunBox;
            }

            return boxes[secondRoundResult.FinalValue];
        }

        public int HidePortalGun(int numberOfBoxes, IRandomProvider randomProvider)
        {
            var result = randomProvider.GenerateFairRandomAsync(numberOfBoxes);

            return result.FinalValue;
        }
    }
}
