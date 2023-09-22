using Laba.Models;
using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab2
{
    public interface ICustomSortingService2: ICustomSorting<double[][], List<SortingAlgorithmStepResultModelLab2>>, ISwap<double>, ISwapRows<double>
    {
        public int ComparesCount { get; }
        public int SwipesCount { get; }
    }
}
