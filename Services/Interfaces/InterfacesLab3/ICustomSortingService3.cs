using Laba.Models;
using Laba.Services.Interfaces.SortingInterfaces;

namespace Laba.Services.Interfaces.InterfacesLab3
{
    public interface ICustomSortingService3: ICustomSorting<double[], List<SortingAlgorithmStepResultModelLab2>>, ISwap<double>
    {
    }
}
