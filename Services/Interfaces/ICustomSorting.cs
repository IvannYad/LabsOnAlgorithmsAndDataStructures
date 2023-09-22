using System.Collections;

namespace Laba.Services.Interfaces
{
    public interface ICustomSorting<TIn, TOut>: ISorting<TIn, TOut> where TIn : IEnumerable
        where TOut : IEnumerable
    {
    }
}
