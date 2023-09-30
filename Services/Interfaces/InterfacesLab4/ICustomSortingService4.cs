using Laba.Models;
using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab4
{
    public interface ICustomSortingService4 : ISorting<int[], int>, ISwap<int>
    {
        void Merge(int[] array, int start, int end, int mid);
        void RecursiveSort(int[] array, int start, int end);
        public List<SortingAlgorithmStepResultModelLab4> Steps { get; }
        public int ComparesCount { get; }
    }
}
