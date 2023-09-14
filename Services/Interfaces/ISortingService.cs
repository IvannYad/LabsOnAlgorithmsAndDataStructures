using System.Collections;

namespace Laba.Services.Interfaces
{
    public interface ISortingService<TSortStepResult, TCollection> where TCollection : IEnumerable
    {
        List<TSortStepResult> Sort(ref TCollection array, bool customTaskChecked = false);
    }
}
