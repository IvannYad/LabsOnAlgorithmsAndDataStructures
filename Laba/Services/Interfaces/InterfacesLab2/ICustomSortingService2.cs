using Laba.Models;
using Laba.Services.Interfaces.SortingInterfaces;
using Microsoft.AspNetCore.Identity;

namespace Laba.Services.Interfaces.InterfacesLab2
{
    public interface ICustomSortingService2: ISorting<double[][], int>, ISwap<double>, ISwapRows<double>
    {
        public List<SortingAlgorithmStepResultModelLab2> Steps { get; }
        public int ComparesCount { get; }
        public int SwipesCount { get; }
    }
}
