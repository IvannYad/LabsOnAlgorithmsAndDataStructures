﻿using Laba.Models;
using Laba.Services.Interfaces.InterfacesLab4;
using System.Diagnostics;

namespace Laba.Services.ServicesLab4
{
    public class OrdinarySortingService4 : IOrdinarySortingService4
    {

        private int _lower;
        private int _upper;
        private int _length;
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

        public double Sort(ref int[] input)
        {
            Stopwatch watch = new Stopwatch();
            Random r = new Random();
            input = Enumerable.Range(0, _length).Select(i => r.Next(_lower, _upper)).ToArray();
            string path = "C:\\Users\\yad7d\\Desktop\\IT\\University\\Algorithms and data structures\\Laba6\\outMerge.txt";
            using StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine($"Before sort for {_length} elements:  " + string.Join(' ', input));
            watch.Start();

            RecursiveSort(input, 0, input.Length - 1);

            watch.Stop();
            writer.WriteLine($"After sort for {_length} elements:  " + string.Join(' ', input));
            return watch.ElapsedTicks;
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

        public void PopulateBounds(int lower, int upper, int length)
        {
            _lower = lower;
            _upper = upper;
            _length = length;
        }
    }
}
