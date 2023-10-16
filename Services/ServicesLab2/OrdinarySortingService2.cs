using Laba.Models;
using Laba.Services.Interfaces.InterfacesLab2;
using System;
using System.Diagnostics;

namespace Laba.Services.ServicesLab2
{
    public class OrdinarySortingService2 : IOrdinarySortingService2
    {
        private int _lower;
        private int _upper;
        private int _length;
        public int Sort(ref int[] input)
        {
            int[] array;
            bool swapped;
            Stopwatch watch = new Stopwatch();
            Random r = new Random();
            array = Enumerable.Range(0, _length).Select(i => r.Next(_lower, _upper)).ToArray();
            int step = (array.Length) / 2;
            watch.Start();
            while (step > 0)
            {
                for (int i = 0; i + step < array.Length; i++)
                {
                    swapped = false;
                    int j = i + step;
                    while (j - step >= 0)
                    {
                        if (array[j] < array[j - step])
                        {
                            swapped = true;
                            Swap(ref array[j], ref array[j - step]);
                            j -= step;
                            continue;
                        }

                        break;
                    }
                }

                step /= 2;
            }
            watch.Stop();
            return (int)watch.ElapsedTicks;
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
