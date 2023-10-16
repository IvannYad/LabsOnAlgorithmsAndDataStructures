using Laba.Services.Interfaces.SortingInterfaces;
using Laba.Services.Interfaces;
using Laba.Models.VM;
using System.Runtime.InteropServices;

namespace Laba.Services.ServicesLab5
{
    public class PrepareCollectionServiceLab6 : IPrepareCollectionService<string, int[]>
    {

        public int[] GetCollectionFromString(string inputCollection)
        {
            var intList = inputCollection
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s));
                
            return intList.ToArray();
        }
    }
}
