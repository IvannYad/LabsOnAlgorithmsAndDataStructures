using Laba.Services.Interfaces.InterfacesLab3;
using System.Diagnostics;

namespace Laba.Services.ServicesLab3
{
    public class OrdinarySortingService3 : IOrdinarySortingService3
    {
        public void RecursiveSort(int[] array, int start, int end)
        {
            if (end - start < 1)
                return;

            int pivotIndex = end;
            int swapMarker = start - 1;
            for (int currentIndex = start; currentIndex <= pivotIndex; currentIndex++)
            {
                if (array[currentIndex] > array[pivotIndex])
                    continue;

                swapMarker++;
                if (currentIndex > swapMarker)
                    Swap(ref array[swapMarker], ref array[currentIndex]);
            }

            RecursiveSort(array, start, swapMarker - 1);

            RecursiveSort(array, swapMarker + 1, end);
        }

        public int Sort(ref int[] input)
        {
            if (input.Length <= 1)
                return 0;

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
