using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab1
{
    public interface IOrdinarySortingService1: ISorting<int[], int>, IFindMin<int[]>, ISwap<int>
    {
        public void PopulateBounds(int lower, int upper, int length);
    }
}
