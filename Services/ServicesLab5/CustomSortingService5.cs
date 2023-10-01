using Laba.Models;
using Laba.Services.Interfaces.InterfacesLab4;
using Laba.Services.Interfaces.InterfacesLab5;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics;

namespace Laba.Services.ServicesLab5
{
    public class CustomSortingService5 : ICustomSortingService5
    {
        public CustomSortingService5()
        {
            Steps = new List<SortingAlgorithmStepResultModelLab5>();
        }

        public (double, int)[] IndexesArray { get; private set; }
        public (double, int)[] AddedIndexesArray { get; private set; }
        public int ComparesCount { get; private set; }

        public List<SortingAlgorithmStepResultModelLab5> Steps { get; private set; }

        public int Sort(ref int[] input)
        {
            if (input.Length < 2)
            {
                throw new ArgumentException("Too small input");
            }

            Dictionary<int, int> indexesDict = new();
            for (int i = 0; i < input.Length; i++)
            {
                if (indexesDict.Keys.Contains(input[i]))
                    indexesDict[input[i]]++;
                else
                    indexesDict.Add(input[i], 1);
            }
            
            indexesDict = indexesDict.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value);
            IndexesArray = indexesDict.Select(p => (p.Key * 1.0 / 100, p.Value)).ToArray();

            var tempList = indexesDict.Select(p => new int[2] { p.Key, p.Value }).ToList();
            for (int i = 1; i < tempList.Count(); i++)
            {
                tempList[i][1] += tempList[i - 1][1];
            }

            indexesDict = tempList.ToDictionary(p => p[0], p => p[1]);
            AddedIndexesArray = indexesDict.Select(p => (p.Key * 1.0 / 100, p.Value)).ToArray();

            double[] result = new double[input.Length];
            result = result.Select(_ => -1.0).ToArray();
            
            Stopwatch watch = new Stopwatch();
            watch.Start();
            // Populate result array with elements in sorted order.
            List<int> sortedIndexes = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                result[indexesDict[input[i]] - 1] = input[i] * 1.0 / 100;
                indexesDict[input[i]] -= 1;
                sortedIndexes.Add(indexesDict[input[i]]);
                Steps.Add(new SortingAlgorithmStepResultModelLab5()
                {
                    Array = result.Select(p => p * 1.0).ToArray(),
                    CurrentIndex = indexesDict[input[i]],
                    SortedIndexes = sortedIndexes.ToArray()
                });
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
