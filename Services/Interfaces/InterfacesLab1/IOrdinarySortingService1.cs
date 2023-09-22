using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab1
{
    public interface IOrdinarySortingService1: ISorting<IEnumerable<int>, int>, IFindMin<int[]>, ISwap<int>
    {
    }
}
