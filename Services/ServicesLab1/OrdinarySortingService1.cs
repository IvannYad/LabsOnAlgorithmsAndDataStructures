﻿using Laba.Models;
using Laba.Services.Interfaces;
using Laba.Services.Interfaces.InterfacesLab1;
using System.Diagnostics;

namespace Laba.Services.ServicesLab1
{
    public class OrdinarySortingService1 : IOrdinarySortingService1
    {
        public int FindMinIndex(int[] array)
        {
            int min = array[0];
            int kMin = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(min) == -1)
                {
                    min = array[i];
                    kMin = i;
                }
            }

            return kMin;
        }

        public int Sort(ref IEnumerable<int> inputCollection)
        {
            int[] tempList;
            tempList = inputCollection.ToArray();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < tempList.Length - 1; i++)
            {
                var minIndex = FindMinIndex(tempList[i..]) + i;
                Swap(ref tempList[i], ref tempList[minIndex]);
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