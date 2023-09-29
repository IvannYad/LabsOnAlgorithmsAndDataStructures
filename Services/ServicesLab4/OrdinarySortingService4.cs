using Laba.Models;
using Laba.Services.Interfaces.InterfacesLab4;
using System.Diagnostics;

namespace Laba.Services.ServicesLab4
{
    public class OrdinarySortingService4 : IOrdinarySortingService4
    {
        public void RecursiveSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                RecursiveSort(array, start, mid);
                RecursiveSort(array, mid + 1, end);
                Merge(array, start, end, mid);
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
            help1[help1.Length - 1] = 1_000_000_000;
            help2 = new int[high - mid + 1];
            for (int r = 0; r < help2.Length - 1; r++)
            {
                help2[r] = array[mid + 1 + r];
            }
            help2[help2.Length - 1] = 1_000_000_000;
            int i = 0, j = 0;
            for (int k = low; k <= high; k++)
            {
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
