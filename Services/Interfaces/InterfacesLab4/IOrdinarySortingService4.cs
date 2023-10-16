using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab4
{
    public interface IOrdinarySortingService4 : ISorting<int[], double>, ISwap<int>
    {
        void Merge(int[] array, int start, int end, int mid);
        void RecursiveSort(int[] array, int start, int end);
        public void PopulateBounds(int lower, int upper, int length);
    }
}
