using Laba.Models;
using Laba.Services.Interfaces.InterfacesLab3;
using System.Diagnostics;

namespace Laba.Services.ServicesLab3
{
    public class CustomSortingService3 : ICustomSortingService3
    {
        public CustomSortingService3()
        {
            Steps = new List<SortingAlgorithmStepResultModelLab3> ();
        }

        public List<SortingAlgorithmStepResultModelLab3> Steps { get; private set; }

        public int ComparesCount { get; private set; }

        public void RecursiveSort(int[] array, int start, int end)
        {
            if (end - start < 1)
                return;

            int pivotIndex = end;
            int swapMarker = start - 1;
            for (int currentIndex = start; currentIndex <= pivotIndex; currentIndex++)
            {
                ComparesCount++;
                if (array[currentIndex] > array[pivotIndex])
                    continue;

                swapMarker++;
                if (currentIndex > swapMarker)
                    Swap(ref array[swapMarker], ref array[currentIndex]);
            }
            
            Steps.Add(new SortingAlgorithmStepResultModelLab3()
            {
                Array = array.Select(i => i * -1.0 / 1000000).ToArray(),
                PivotIndex = swapMarker,
                StartIndex = start,
                EndIndex = end
            });

            RecursiveSort(array, start, swapMarker - 1);

            RecursiveSort(array, swapMarker + 1, end);
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
    }
}
