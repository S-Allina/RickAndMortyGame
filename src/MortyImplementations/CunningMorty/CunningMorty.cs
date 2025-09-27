using RickAndMortyGame.Core.Interfaces;
using RickAndMortyGame.Core.Models;

namespace CunningMorty
{
    public class CunningMorty : IMorty
    {
        public string Name => "EvilMorty";

        const double HONEST_RATE = 0.67;
        const double CHEAT_RATE = 0.33;

        public int DecideWhichBoxToSave(int[] boxes, int portalGunBox, FairRandomResult secondRoundResult)
        {
            if (ShouldRemovePortalGun(boxes.Length))
            {
                return boxes.Where(b => b != portalGunBox).OrderBy(b => b).First();
            }
            else
            {
                return boxes.Contains(portalGunBox) ? portalGunBox : boxes[secondRoundResult.FinalValue];
            }
        }

        private bool ShouldRemovePortalGun(int remainingBoxes)
        {
            return new Random().Next(3) == 0;
        }

        public double CalculateWinProbablyWhenSwich(int numOfBoxes)
        {
            double honestProbability = (double)(numOfBoxes - 1) / numOfBoxes;
            double cheatProbability = 0;

            return honestProbability * HONEST_RATE + cheatProbability * CHEAT_RATE;
        }

        public double CalculateWinProbablyWhenStay(int numOfBoxes)
        {
            double honestProbability = 1.0 / numOfBoxes;
            double cheatProbability = 0;

            return honestProbability * HONEST_RATE + cheatProbability * CHEAT_RATE;
        }

        public int HidePortalGun(int numberOfBoxes, IRandomProvider randomProvider)
        {
            var result = randomProvider.GenerateFairRandom(numberOfBoxes);

            return result.FinalValue;
        }
    }
}
