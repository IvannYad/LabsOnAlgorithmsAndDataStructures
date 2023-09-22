using System.Collections;

namespace Laba.Services.Interfaces
{
    public interface ISorting<TIn, TOut> where TIn : IEnumerable
    {
        TOut Sort(ref TIn input);
    }
}
