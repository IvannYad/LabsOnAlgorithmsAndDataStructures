using Laba.Models;
using Laba.Services.Interfaces.InterfacesLab2;
using System;

namespace Laba.Services.SortingServicesLab2
{
    public class OrdinarySortingService2 : IOrdinarySortingService2
    {
        public int Sort(ref IEnumerable<int> input)
        {
            int[] array = input.ToArray();
            int step = (array.Length) / 2;
            bool swapped;
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

            return 0;
        }

        public void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }
}
