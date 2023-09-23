using Laba.Services.Interfaces;
using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.ServicesLab3
{
    public class PrepareCollectionServiceLab3 : IPrepareCollectionService<string, int[]>, IFindMin<int[]>, IFindMax<int[]>
    {
        public int FindMaxIndex(int[] array)
        {
            int max = array[0];
            int kMax = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(max) == 1)
                {
                    max = array[i];
                    kMax = i;
                }
            }

            return kMax;
        }

        public int FindMinIndex(int[] array)
        {
            int min = array[0];
            int kMin = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(min) == -1)
                {
                    min = array[i];
                    kMin = i;
                }
            }

            return kMin;
        }

        public int[] GetCollectionFromString(string inputCollection)
        {
            var intList = inputCollection
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(e => double.Parse(e))
                .Select(d => (int)(d * 1000000 * -1))
                .ToList();
            
            if (intList.Count <= 2)
                return new int[0];

            intList.RemoveAt(FindMinIndex(intList.ToArray()));
            intList.RemoveAt(FindMinIndex(intList.ToArray()));

            return intList.ToArray();
        }
    }
}
