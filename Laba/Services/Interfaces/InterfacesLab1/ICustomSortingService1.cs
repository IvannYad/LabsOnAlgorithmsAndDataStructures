using Laba.Models;
using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab1
{
    public interface ICustomSortingService1: ISorting<string[], int>, IFindMin<string[]>, ISwap<string>
    {
        public List<SortingAlgorithmStepResultModelLab1> Steps { get; }
        public int ComparesCount { get; }
    }
}
