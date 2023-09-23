namespace Laba.Services.Interfaces.SortingInterfaces
{
    public interface ISwap<T>
    {
        void Swap(ref T a, ref T b);
    }
}
