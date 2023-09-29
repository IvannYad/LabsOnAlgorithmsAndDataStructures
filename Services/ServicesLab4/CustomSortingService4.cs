using Laba.Models;
using Laba.Services.Interfaces.InterfacesLab4;
using System.Diagnostics;

namespace Laba.Services.ServicesLab4
{
    public class CustomSortingService4 : ICustomSortingService4
    {
        public CustomSortingService4()
        {
            Steps = new List<SortingAlgorithmStepResultModelLab4>();
        }


        public List<SortingAlgorithmStepResultModelLab4> Steps { get; private set; }

        public int ComparesCount { get; private set; }

        public void RecursiveSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                RecursiveSort(array, start, mid);
                RecursiveSort(array, mid + 1, end);
                Merge(array, start, end, mid);
                Steps.Add(new SortingAlgorithmStepResultModelLab4()
                {
                    Array = array.Select(i => i * -1.0 / 1000000).ToArray(),
                    StartIndex = start,
                    EndIndex = end
                });

            }
        }

        public int Sort(ref int[] input)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            RecursiveSort(input, 0, input.Length - 1);

            watch.Stop();

            return (int)watch.ElapsedTicks;
        }

        public void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        public void Merge(int[] array, int low, int high, int mid)
        {
            int[] help1, help2;
            help1 = new int[mid - low + 2];
            for (int h = 0; h < help1.Length - 1; h++)
            {
                help1[h] = array[low + h];
            }
            help1[help1.Length - 1] = 3409509;
            help2 = new int[high - mid + 1];
            for (int r = 0; r < help2.Length - 1; r++)
            {
                help2[r] = array[mid + 1 + r];
            }
            help2[help2.Length - 1] = 3409509;
            int i = 0, j = 0;
            for (int k = low; k <= high; k++)
            {
                ComparesCount++;
                if (help1[i] <= help2[j])
                {
                    array[k] = help1[i];
                    i++;
                }
                else
                {
                    array[k] = help2[j];
                    j++;
                }
            }
        }
    }
}
