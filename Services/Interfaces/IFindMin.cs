using System.Collections;
using System.Numerics;

namespace Laba.Services.Interfaces
{
    public interface IFindMin<TCollection> where TCollection : IEnumerable
    {
        int FindMinIndex(TCollection array);
    }
}
