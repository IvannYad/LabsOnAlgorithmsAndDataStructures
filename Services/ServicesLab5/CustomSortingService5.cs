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

        public void RecursiveSort((string, long)[] input, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                RecursiveSort(input, start, mid);
                RecursiveSort(input, mid + 1, end);
                Merge(input, start, end, mid);
                Steps.Add(new SortingAlgorithmStepResultModelLab4()
                {
                    Array = input.Select(p => (p.Item1, p.Item2 * 1.0 / 1000000)).ToArray(),
                    StartIndex = start,
                    EndIndex = end
                });

            }
        }

        public int Sort(ref (string, long)[] input)
        {
            if (input.Length < 2)
            {
                throw new ArgumentException();
            }

            Stopwatch watch = new Stopwatch();
            watch.Start();

            RecursiveSort(input, 0, input.Length - 1);

            watch.Stop();

            return (int)watch.ElapsedTicks;
        }

        public void Merge((string, long)[] input, int low, int high, int mid)
        {
            (string, long)[] help1, help2;
            help1 = new (string, long)[mid - low + 2];
            for (int h = 0; h < help1.Length - 1; h++)
            {
                help1[h] = input[low + h];
            }
            help1[help1.Length - 1].Item1 = "ZZZZZZZ";
            help2 = new (string, long)[high - mid + 1];
            for (int r = 0; r < help2.Length - 1; r++)
            {
                help2[r] = input[mid + 1 + r];
            }
            help2[help2.Length - 1].Item1 = "ZZZZZZZ";
            int i = 0, j = 0;
            for (int k = low; k <= high; k++)
            {
                ComparesCount++;
                if (help1[i].Item1.CompareTo(help2[j].Item1) == -1)
                {
                    input[k] = help1[i];
                    i++;
                }
                else
                {
                    input[k] = help2[j];
                    j++;
                }
            }
        }

        public void Swap(ref (string, long) a, ref (string, long) b)
        {
            (string, long) t = a;
            a = b;
            b = t;
        }
    }
}
