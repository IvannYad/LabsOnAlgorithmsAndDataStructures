namespace Laba.DataStructures.Interfaces
{
    public interface ISingleLinkedList<TInfo>: IEnumerable<Node<TInfo>>
    {
        public Node<TInfo> Start { get; set; }
        bool AddAfter(Node<TInfo> currentNode, Node<TInfo> nodeToAdd);
    }
}
