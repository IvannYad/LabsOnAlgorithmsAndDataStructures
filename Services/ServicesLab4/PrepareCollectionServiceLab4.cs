using Laba.Services.Interfaces.SortingInterfaces;
using Laba.Services.Interfaces;
using Laba.Models.VM;
using System.Runtime.InteropServices;

namespace Laba.Services.ServicesLab4
{
    public class PrepareCollectionServiceLab4 : IPrepareCollectionService<string, (string, int)[]>
    {

        public (string, int)[] GetCollectionFromString(string inputCollection)
        {
            var elemList = inputCollection
                .Split("/", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, double> products = elemList
                .Select(p => p.Split(":", StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(p => p[0], p => double.Parse(p[1]));

            if (products.Values.Any(i => i >= 1_000))
            {
                throw new ArgumentException();
            }

            (string, int)[] toReturn = products.Select(p => (p.Key, (int)p.Value * 1000000)).ToArray();

            if (products.Count <= 2)
                return new (string, int)[0];

            return toReturn;
        }
    }
}
