using Laba.Models;
using Laba.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace Laba.Services
{
    public class SortingServiceLab2 : ISortingServiceLab2
    {
        public int ComparesCount { get; private set; }

        public int SwipesCount { get; private set; }

        public List<SortingAlgorithmStepResultModelLab2> Sort(ref double[][] matr, bool customTaskChecked = false)
        {
            // List stores information that will be passed to view.
            List<SortingAlgorithmStepResultModelLab2> toReturn = new ();
            
            // sums - auxiliary array that stores sums of matrix rows.
            double[] sums = new double[matr.GetLength(0)];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                sums[i] = matr[i].Sum(x => x);
            }

            int step = (matr.Length) / 2;
            int iteration = 1;
            bool swapped;
            while (step > 0)
            {
                for (int i = 0; i + step < sums.Length; i++)
                {
                    swapped = false;
                    int[] swappableIdexes = GenerateSwappableIndexes(i % step, sums.Length, step);

                    int j = i + step;
                    while (j - step >= 0)
                    {
                        ComparesCount++;
                        if (sums[j] < sums[j - step])
                        {
                            SwipesCount++;
                            swapped = true;
                            var matrBefore = (double[][])matr.Clone();
                            var sumsBefore = (double[])sums.Clone();
                            Swap(ref sums[j], ref sums[j - step]);

                            SwapRows(ref matr[j], ref matr[j - step]);
                            var matrAfter = (double[][])matr.Clone();
                            var sumsAfter = (double[])sums.Clone();
                            toReturn.Add(new SortingAlgorithmStepResultModelLab2()
                            {
                                Iteration = iteration++,
                                Step = step,
                                SwappableIndexes = swappableIdexes,
                                MatrixBefore = matrBefore,
                                MatrixAfter = matrAfter,
                                SumsBefore = sumsBefore,
                                SumsAfter = sumsAfter,
                                Index1ToSwap = j,
                                Index2ToSwap = j - step
                            });

                            j -= step;
                            continue;
                        }

                        break;
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
                toReturn.Add(start);
                start += step;
            }

            return toReturn.ToArray();
        }
    }
}
