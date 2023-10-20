using Laba.Models;
using Laba.Services.Interfaces.InterfacesLab2;
using Laba.Services.Interfaces.SortingInterfaces;
using System;
using System.Diagnostics;

namespace Laba.Services.ServicesLab2
{
    public class CustomSortingService2 : ICustomSortingService2
    {
        public CustomSortingService2()
        {
            Steps = new List<SortingAlgorithmStepResultModelLab2>();
        }
        public int ComparesCount { get; private set; }

        public int SwipesCount { get; private set; }
        public List<SortingAlgorithmStepResultModelLab2> Steps { get; private set; }

        public int Sort(ref double[][] input)
        {
            // sums - auxiliary array that stores sums of matrix rows.
            double[] sums = new double[input.GetLength(0)];
            for (int i = 0; i < input.GetLength(0); i++)
            {
                sums[i] = input[i].Sum(x => x);
            }

            Stopwatch watch = new Stopwatch();
            watch.Start();

            int step = (input.Length) / 2;
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
                            var matrBefore = (double[][])input.Clone();
                            var sumsBefore = (double[])sums.Clone();
                            Swap(ref sums[j], ref sums[j - step]);

                            SwapRows(ref input[j], ref input[j - step]);
                            var matrAfter = (double[][])input.Clone();
                            var sumsAfter = (double[])sums.Clone();
                            Steps.Add(new SortingAlgorithmStepResultModelLab2()
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

            watch.Stop();
            return (int)watch.ElapsedTicks;
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
