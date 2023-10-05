using Laba.Models;
using Laba.Services.Interfaces.InterfacesLab4;
using Laba.Services.Interfaces.InterfacesLab5;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics;

namespace Laba.Services.ServicesLab5
{
    public class OrdinarySortingService5 : IOrdinarySortingService5
    {
        
        public int Sort(ref int[] input)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            int[] indexesArray = new int[11];
            input.ToList().ForEach(i => indexesArray[i]++);
            for (int i = 1; i < indexesArray.Length; i++)
            {
                indexesArray[i] = indexesArray[i] + indexesArray[i - 1];
            }

            int[] result = new int[input.Length];
            result = result.Select(_ => -1).ToArray();

            // Populate result array with elements in sorted order.
            for (int i = 0; i < input.Length; i++)
            {
                result[--indexesArray[input[i]]] = input[i];
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

        
    }
}
