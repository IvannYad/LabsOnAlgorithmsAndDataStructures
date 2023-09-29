using Laba.Models;
using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab4
{
    public interface ICustomSortingService4 : ISorting<double[], double>, ISwap<double>
    {
        void RecursiveSort(double[] array, int start, int end);
        public List<SortingAlgorithmStepResultModelLab4> Steps { get; }
        public int ComparesCount { get; }
    }
}
