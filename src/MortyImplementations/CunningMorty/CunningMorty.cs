using RickAndMortyGame.Core.Interfaces;

namespace CunningMorty
{
    public class CunningMorty : IMorty
    {
        public string Name => "EvilMorty";

        const double HONEST_RATE = 0.67;
        const double CHEAT_RATE = 0.33;

        public async Task<int> DecideWhichBoxToSaveAsync(int[] boxes, int portalGunBox, IRandomProvider randomProvider)
        {
            if (ShouldRemovePortalGun(boxes.Length))
            {
                return boxes.Where(b => b != portalGunBox).OrderBy(b => b).First();
            }
            else
            {
                var result = await randomProvider.GenerateFairRandomAsync(boxes.Length);

                return boxes.Contains(portalGunBox) ? portalGunBox : boxes[result.FinalValue];
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

        public async Task<int> HidePortalGunAsync(int numberOfBoxes, IRandomProvider randomProvider)
        {
            var result = await randomProvider.GenerateFairRandomAsync(numberOfBoxes);

            return result.FinalValue;
        }
    }
}
