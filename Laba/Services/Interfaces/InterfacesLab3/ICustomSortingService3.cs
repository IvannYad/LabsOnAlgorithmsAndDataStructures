using Laba.Models;
using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab3
{
    public interface ICustomSortingService3: ISorting<int[], int>, ISwap<int>
    {
        public void RecursiveSort(int[] array, int start, int end);
        public List<SortingAlgorithmStepResultModelLab3> Steps { get; }
        public int ComparesCount { get; }
    }
}
