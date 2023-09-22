using Laba.Models;
using Laba.Services.Interfaces;
using Laba.Services.Interfaces.InterfacesLab1;

namespace Laba.Services.SortingServicesLab1
{
    public class CustomSortingService1 : ICustomSortingService1
    {
        public int ComparesCount { get; private set; }

        public int FindMinIndex(string[] array)
        {
            string min = array[0];
            int kMin = 0;
            for (int i = 1; i < array.Length; i++)
            {
                ComparesCount++;
                if (array[i].CompareTo(min) == -1)
                {
                    min = array[i];
                    kMin = i;
                }
            }

            return kMin;
        }

        public List<SortingAlgorithmStepResultModelLab1> Sort(ref string[] input)
        {
            var result = new List<SortingAlgorithmStepResultModelLab1>();
            string[] tempArray;
            // If calculation of custom task is chosen, remove elements, which length is > 8.
            var tempList = input.ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                if (tempList[i].Length > 8)
                {
                    tempList.RemoveAt(i);
                    i--;
                }
            }

            input = tempList.ToArray();
            tempArray = input.ToArray();

            for (int i = 0; i < tempArray.Length - 1; i++)
            {
                var minIndex = FindMinIndex(tempArray[i..]) + i;
                Swap(ref tempArray[i], ref tempArray[minIndex]);
                // Next line of code for adding result of each sotring step to ViewModel,
                // in order to display in webpage.
                result.Add(new SortingAlgorithmStepResultModelLab1() { Index1ToSwap = i, Index2ToSwap = minIndex, Array = (string[])tempArray.Clone(), LastIndexSorted = i - 1 });
            }

            return result;
        }

        public void Swap(ref string a, ref string b)
        {
            string t = a;
            a = b;
            b = t;
        }
    }
}
