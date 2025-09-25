using RickAndMortyGame.Core.Interfaces;

namespace LazyMorty
{
    public class LazyMorty : IMorty
    {
        public string Name => "LazyMorty";

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

        public async Task<int> DecideWhichBoxToSaveAsync(int[] boxes, int portalGunBox, IRandomProvider randomProvider)
        {
            await Task.Delay(50);

            if (boxes.Contains(portalGunBox))
            {
                return portalGunBox;
            }

            return boxes.OrderBy(b => b).First();
        }

        public async Task<int> HidePortalGunAsync(int numberOfBoxes, IRandomProvider randomProvider)
        {
            var result = await randomProvider.GenerateFairRandomAsync(numberOfBoxes);

            return result.FinalValue;
        }
    }
}
