using Laba.Models;
using Laba.Services.Interfaces.SortingInterfaces;
using System.Runtime.InteropServices;

namespace Laba.Services.Interfaces.InterfacesLab5
{
    public interface ICustomSortingService5 : ISorting<int[], int>, ISwap<int>
    {
        public List<SortingAlgorithmStepResultModelLab5> Steps { get; }
        public int ComparesCount { get; }
    }
}
