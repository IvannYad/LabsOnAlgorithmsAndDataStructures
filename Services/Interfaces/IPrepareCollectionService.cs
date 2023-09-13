using System.Collections;

namespace Laba.Services.Interfaces
{
    public interface IPrepareCollectionService<TInCollection, TOutCollection> where TInCollection: IEnumerable
        where TOutCollection : IEnumerable
    {
        TOutCollection GetCollectionFromString(TInCollection inputCollection);
    }
}
