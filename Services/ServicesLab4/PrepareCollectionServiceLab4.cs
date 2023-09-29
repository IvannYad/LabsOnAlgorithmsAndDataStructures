using Laba.Services.Interfaces.SortingInterfaces;
using Laba.Services.Interfaces;

namespace Laba.Services.ServicesLab4
{
    public class PrepareCollectionServiceLab4 : IPrepareCollectionService<string, int[]>
    {
        public int[] GetCollectionFromString(string inputCollection)
        {
            var intList = inputCollection
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(e => double.Parse(e))
                .Select(d => (int)(d * 1000000 * -1))
                .ToList();

            if (intList.Count <= 2)
                return new int[0];

            double avg = intList.Average(i => i);

            intList = intList.Where(i => i <= avg).ToList();

            return intList.ToArray();
        }
    }
}
