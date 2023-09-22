namespace Laba.Services.Interfaces.SortingInterfaces
{
    public interface ISwapRows<T>
    {
        void SwapRows(ref T[] a, ref T[] b);
    }
}
