using Laba.Models;
using Laba.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace Laba.Services
{
    public class SortingServiceLab2 : ISortingServiceLab2
    {
        public int ComparesCount { get; private set; }

        public int SwipesCount { get; private set; }

        public IEnumerable<SortingAlgorithmStepResultModelLab2> Sort(ref double[][] array, bool customTaskChecked = false)
        {
            // List stores information that will be passed to view.
            List<SortingAlgorithmStepResultModelLab2> toReturn = new ();
            
            double[][] tempMatrix = (double[][])array.Clone();
            // sums - auxiliary array that stores sums of matrix rows.
            double[] sums = new double[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                sums[i] = array[i].Sum(x => x);
            }

            int step = array.Length / 2;
            int iteration = 1;
            bool swapped;
            while (step > 0)
            {
                for (int i = 0; i < step; i++)
                {
                    swapped = true;
                    // Bubble sort with flag.
                    while (swapped)
                    {
                        swapped = false;
                        int[] swappableIdexes = GenerateSwappableIndexes(i, sums.Length, step);
                        for (int j = i; j + step < sums.Length; j += step)
                        {
                            ComparesCount++;
                            if (sums[j] > sums[j + step])
                            {
                                SwipesCount++;
                                swapped = true;
                                Swap(ref sums[j], ref sums[j + step]);

                                SwapRows(ref tempMatrix[j], ref tempMatrix[j + step]);

                                toReturn.Add(new SortingAlgorithmStepResultModelLab2()
                                { 
                                    Iteration = iteration++, 
                                    Step = step, 
                                    SwappableIndexes =swappableIdexes, 
                                    Matrix = tempMatrix, 
                                    Sums = sums, 
                                    Index1ToSwap = j, 
                                    Index2ToSwap = j + step
                                });
                            }
                        }
                    }

                }

                step /= 2;
            }

            return toReturn;

        }

        public void Swap(ref double a, ref double b)
        {
            double t = a;
            a = b;
            b = t;
        }

        public void SwapRows(ref double[] a, ref double[] b)
        {
            var temp = (double[])a.Clone();
            a = b; 
            b = temp;
        }
        private int[] GenerateSwappableIndexes(int start, int end, int step)
        {
            List<int> toReturn = new List<int>();
            while (start < end)
            {
                toReturn.Add(step);
                start += step;
            }

            return toReturn.ToArray();
        }
    }
}
