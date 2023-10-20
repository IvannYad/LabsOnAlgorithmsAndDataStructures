using Laba.Services.Interfaces.SortingInterfaces;
using Laba.Services.Interfaces;
using Laba.Models.VM;
using System.Runtime.InteropServices;

namespace Laba.Services.ServicesLab4
{
    public class PrepareCollectionServiceLab4 : IPrepareCollectionService<string, (string, long)[]>
    {

        public (string, long)[] GetCollectionFromString(string inputCollection)
        {
            var elemList = inputCollection
                .Split("/", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, double> products = elemList
                .Select(p => p.Split(":", StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(p => p[0], p => double.Parse(p[1]));

            // Price validation.
            if (products.Values.Any(i => i >= 10_000 || i <= 0))
            {
                throw new ArgumentException();
            }

            // Validation for product title: product title must begin with capital letter.
            if (products.Keys.Any(p => char.IsLower(p[0])))
            {
                throw new ArgumentException();
            }

            (string, long)[] toReturn = products.Select(p => (p.Key, (long)(p.Value * 1000000))).ToArray();

            if (products.Count <= 2)
                return new (string, long)[0];

            return toReturn;
        }
    }
}
