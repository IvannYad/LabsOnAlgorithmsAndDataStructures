namespace Laba.DataStructures.Interfaces
{
    public interface IPriorityQueue<T> : IEnumerable<T>
    {
        public int Count { get; }
        public bool IsEmpty { get; }
        
        Node<T> Start { get; }
        double MinElement();
        double MaxElement();
        void Enqueue(int priority, double value);
        double Dequeue();
        double Peek();
        int IndexOf(double value);
        double ReturnByIndex(int index);
    }
}
