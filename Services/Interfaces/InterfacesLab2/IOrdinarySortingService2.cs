using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab2
{
    public interface IOrdinarySortingService2: ISorting<IEnumerable<int>, int>, ISwap<int>
    {
    }
}
