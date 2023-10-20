using System.Collections;

namespace Laba.Services.Interfaces.SortingInterfaces
{
    public interface IFindMax<TCollection> where TCollection : IEnumerable
    {
        int FindMaxIndex(TCollection array);
    }
}
