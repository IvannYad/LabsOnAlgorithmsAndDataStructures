using Laba.Models;
using Laba.Services.Interfaces;

namespace Laba.Services
{
    public class SortingServiceLab1 : ISortingServiceLab1
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

        public IEnumerable<SortingAlgorithmStepResultModelLab1> Sort(ref string[] array, bool customTaskChecked = false)
        {
            var result = new List<SortingAlgorithmStepResultModelLab1>();
            string[] tempArray;
            // If calculation of custom task is chosen, remove elements, which length is > 8.
            if (customTaskChecked)
            {
                var tempList = array.ToList();
                for (int i = 0; i < tempList.Count; i++)
                {
                    if (tempList[i].Length > 8)
                    {
                        tempList.RemoveAt(i);
                        i--;
                    }
                }

                array = tempList.ToArray();
            }

            tempArray = (string[])array.Clone();

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
