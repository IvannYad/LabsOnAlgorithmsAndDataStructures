using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab3
{
    public interface IOrdinarySortingService3: ISorting<int[], double>, ISwap<int>
    {
        void RecursiveSort(int[] array, int start, int end);
        public void PopulateBounds(int lower, int upper, int length);
    }
}
