namespace Laba.DataStructures
{
    public class Node<TInfo>
    {
        public Node(TInfo info)
        {
            Info = info;
            Next = null;
        }
        public Node<TInfo>? Next { get; set; }

        public TInfo Info { get; set; }
    }
}
