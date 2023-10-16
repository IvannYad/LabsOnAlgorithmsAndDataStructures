using Laba.Models;
using Laba.Services.Interfaces.InterfacesLab4;
using Laba.Services.Interfaces.InterfacesLab5;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics;

namespace Laba.Services.ServicesLab5
{
    public class OrdinarySortingService5 : IOrdinarySortingService5
    {
        private int _lower;
        private int _upper;
        private int _length;
        public double Sort(ref int[] input)
        {
            Stopwatch watch = new Stopwatch();
            Random r = new Random();
            input = Enumerable.Range(0, _length).Select(i => r.Next(_lower, _upper) - _lower).ToArray();
            int[] indexesArray = new int[_upper - _lower];
            int[] result = new int[input.Length];
            result = result.Select(_ => -1).ToArray();
            string path = "C:\\Users\\yad7d\\Desktop\\IT\\University\\Algorithms and data structures\\Laba6\\outCount.txt";
            using StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine($"Before sort for {_length} elements:  " + string.Join(' ', input));
            watch.Start();
            input.ToList().ForEach(i => indexesArray[i]++);
            for (int i = 1; i < indexesArray.Length; i++)
            {
                indexesArray[i] = indexesArray[i] + indexesArray[i - 1];
            }

            // Populate result array with elements in sorted order.
            for (int i = 0; i < input.Length; i++)
            {
                result[--indexesArray[input[i]]] = input[i];
            }

            watch.Stop();
            writer.WriteLine($"After sort for {_length} elements:  " + string.Join(' ', result));
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
