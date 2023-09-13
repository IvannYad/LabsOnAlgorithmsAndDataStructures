using Laba.Models;
using System.Numerics;
using System.Xml.Linq;

namespace Laba.Services.Interfaces
{
    public interface ISortingServiceLab2: ISortingService<SortingAlgorithmStepResultModelLab2, double[][]>
    {
        public int ComparesCount { get; }
        public int SwipesCount { get; }
        void Swap(ref double a, ref double b);
        void SwapRows(ref double[] a, ref double[] b);
    }
}
