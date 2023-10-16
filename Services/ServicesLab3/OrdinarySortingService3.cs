using Laba.Services.Interfaces.InterfacesLab3;
using System.Diagnostics;

namespace Laba.Services.ServicesLab3
{
    public class OrdinarySortingService3 : IOrdinarySortingService3
    {
        private int _lower;
        private int _upper;
        private int _length;
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

        public double Sort(ref int[] input)
        {
            Stopwatch watch = new Stopwatch();
            Random r = new Random();
            input = Enumerable.Range(0, _length).Select(i => r.Next(_lower, _upper)).ToArray();
            watch.Start();

            RecursiveSort(input, 0, input.Length - 1);

            watch.Stop();

            return watch.ElapsedTicks;
        }

        public void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        public void PopulateBounds(int lower, int upper, int length)
        {
            _lower = lower;
            _upper = upper;
            _length = length;
        }
    }
}
