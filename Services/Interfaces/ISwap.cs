namespace Laba.Services.Interfaces
{
    public interface ISwap<T>
    {
        void Swap(ref T a, ref T b);
    }
}
