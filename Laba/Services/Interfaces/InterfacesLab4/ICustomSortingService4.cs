using Laba.Models;
using Laba.Services.Interfaces.SortingInterfaces;
using System.Runtime.InteropServices;

namespace Laba.Services.Interfaces.InterfacesLab4
{
    public interface ICustomSortingService4 : ISorting<(string, long)[], int>, ISwap<(string, long)>
    {
        void Merge((string, long)[] input, int low, int high, int mid);
        void RecursiveSort((string, long)[] input, int start, int end);
        public List<SortingAlgorithmStepResultModelLab4> Steps { get; }
        public int ComparesCount { get; }
    }
}
