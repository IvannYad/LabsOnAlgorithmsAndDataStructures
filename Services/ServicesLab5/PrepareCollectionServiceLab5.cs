using Laba.Services.Interfaces.SortingInterfaces;
using Laba.Services.Interfaces;
using Laba.Models.VM;
using System.Runtime.InteropServices;

namespace Laba.Services.ServicesLab5
{
    public class PrepareCollectionServiceLab5 : IPrepareCollectionService<string, int[]>
    {

        public int[] GetCollectionFromString(string inputCollection)
        {
            var intList = inputCollection
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select((e, i) => i % 2 == 0 ? Math.Sqrt(Math.Abs(double.Parse(e) - 10)) : double.Parse(e))
                .Select(d => (int)(d * 100))
                .ToList();
        
            if (intList.Count <= 2)
                return new int[0];

            return intList.ToArray();
        }
    }
}
