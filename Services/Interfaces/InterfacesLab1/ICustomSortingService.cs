using Laba.Models;

namespace Laba.Services.Interfaces.InterfacesLab1
{
    public interface ICustomSortingService: ICustomSorting<IEnumerable<string>, List<SortingAlgorithmStepResultModelLab1>>, IFindMin<string[]>, ISwap<string>
    {
    }
}
