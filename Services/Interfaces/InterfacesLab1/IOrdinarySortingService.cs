namespace Laba.Services.Interfaces.InterfacesLab1
{
    public interface IOrdinarySortingService: ISorting<IEnumerable<int>, int>, IFindMin<int[]>, ISwap<int>
    {
    }
}
