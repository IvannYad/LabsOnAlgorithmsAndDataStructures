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
                .Select(d => (int)(d * 1000000))
                .ToList();

            if (intList.Any(i => i < 0 || i > 10))
            {
                throw new ArgumentException();
            }

            if (intList.Count <= 2)
                return new int[0];

            

            return intList.ToArray();
        }
    }
}
