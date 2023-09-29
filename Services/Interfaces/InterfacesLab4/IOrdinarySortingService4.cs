using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab4
{
    public interface IOrdinarySortingService4 : ISorting<IEnumerable<int>, int>, ISwap<int>
    {
        void RecursiveSort(int[] array, int start, int end);
    }
}
