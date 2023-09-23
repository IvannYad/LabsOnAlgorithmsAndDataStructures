using Laba.Models;
using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab1
{
    public interface ICustomSortingService1: ICustomSorting<string[], List<SortingAlgorithmStepResultModelLab1>>, IFindMin<string[]>, ISwap<string>
    {
        public int ComparesCount { get; }
    }
}
