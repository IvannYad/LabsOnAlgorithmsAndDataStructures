using Laba.DataStructures.Interfaces;
using System.Collections;

namespace Laba.DataStructures
{
    public class SingleLinkedList<TInfo> : ISingleLinkedList<TInfo>
    {
        public SingleLinkedList()
        {
            Start = null;    
        }

        public Node<TInfo> Start { get; set; }

        public bool AddAfter(Node<TInfo> currentNode, Node<TInfo> nodeToAdd)
        {
            try
            {
                nodeToAdd.Next = currentNode.Next;
                currentNode.Next = nodeToAdd;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerator<Node<TInfo>> GetEnumerator()
        {
            Node<TInfo>? currentNode = Start;
            while (currentNode is not null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
