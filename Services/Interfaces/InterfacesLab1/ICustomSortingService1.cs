using Laba.Models;

namespace Laba.Services.Interfaces.InterfacesLab1
{
    public interface ICustomSortingService1: ICustomSorting<string[], List<SortingAlgorithmStepResultModelLab1>>, IFindMin<string[]>, ISwap<string>
    {
        public int ComparesCount { get; }
    }
}
