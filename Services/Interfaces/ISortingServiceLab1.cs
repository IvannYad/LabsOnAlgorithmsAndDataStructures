using Laba.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace Laba.Services.Interfaces
{
    public interface ISortingServiceLab1 : ISortingService<SortingAlgorithmStepResultModelLab1, string[]>, IFindMin<string[]>
    {
        public int ComparesCount { get; }
        void Swap(ref string a, ref string b);
    }
}
