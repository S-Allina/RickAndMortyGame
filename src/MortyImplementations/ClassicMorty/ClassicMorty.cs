using RickAndMortyGame.Core.Interfaces;

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

        public async Task<int> DecideWhichBoxToSaveAsync(int[] boxes, int portalGunBox, IRandomProvider randomProvider)
        {
            if (boxes.Contains(portalGunBox))
            {
                return portalGunBox;
            }

            var result = await randomProvider.GenerateFairRandomAsync(boxes.Length);

            return boxes[result.FinalValue];
        }

        public async Task<int> HidePortalGunAsync(int numberOfBoxes, IRandomProvider randomProvider)
        {
            var result = await randomProvider.GenerateFairRandomAsync(numberOfBoxes);

            return result.FinalValue;
        }
    }
}
