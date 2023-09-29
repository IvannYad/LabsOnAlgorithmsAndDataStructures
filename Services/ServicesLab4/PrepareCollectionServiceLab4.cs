using Laba.Services.Interfaces.SortingInterfaces;
using Laba.Services.Interfaces;
using Laba.Models.VM;

namespace Laba.Services.ServicesLab4
{
    public class PrepareCollectionServiceLab4 : IPrepareCollectionService<string, int[]>
    {

        public int[] GetCollectionFromString(string inputCollection)
        {
            var intList = inputCollection
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(e => double.Parse(e))
                .ToList();

            if (intList.Any(i => i >= 1_000))
            {
                throw new ArgumentException();
            }

            intList = intList.Select(d => d * 1000000).ToList();

            if (intList.Count <= 2)
                return new int[0];

            return intList.Select(d => (int)d).ToArray();
        }
    }
}
