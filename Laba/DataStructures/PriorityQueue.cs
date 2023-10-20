using Laba.DataStructures.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Laba.DataStructures
{
    public class PriorityQueue : IPriorityQueue<(int Priority, double Value)>
    {
        private SingleLinkedList<(int priority, double Value)> _linkedList;
        public int Count { get; private set; }

        public bool IsEmpty { get; private set; }

        public Node<(int Priority, double Value)> Start => _linkedList.Start;

        public PriorityQueue()
        {
            _linkedList = new SingleLinkedList<(int priority, double Value)>();
            IsEmpty = true;
        }

        public double MinElement()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            double min = _linkedList.Start.Info.Value;

            foreach (var node in _linkedList)
            {
                if (node.Info.Value < min)
                {
                    min = node.Info.Value;
                }
            }

            return min;
        }

        public double MaxElement()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            double max = _linkedList.Start.Info.Value;

            foreach (var node in _linkedList)
            {
                if (node.Info.Value > max)
                {
                    max = node.Info.Value;
                }
            }

            return max;
        }

        public void Enqueue(int priority, double value)
        {

            Node<(int Priority, double Value)> current = _linkedList.Start;
            Node<(int Priority, double Value)> toAdd = new Node<(int Priority, double Value)>((priority, value));
            if (current is null)
            {
                _linkedList.Start = toAdd;
                Count++;
                IsEmpty = false;
                return;
            }

            if (current.Next is null)
            {
                _linkedList.AddAfter(_linkedList.Start, toAdd);
                Count++;
                IsEmpty = false;
                return;
            }

            while (current.Next is not null && current.Next.Info.Priority < priority)
            {
                current = current.Next;
            }

            _linkedList.AddAfter(_linkedList.Start, toAdd);
            Count++;
            IsEmpty = false;
            return;

        }

        public double Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            Node<(int Priority, double Value)> first = _linkedList.Start;
            Count--;
            if (_linkedList.Start.Next is null)
            {
                _linkedList = new SingleLinkedList<(int Priority, double Value)>();
                IsEmpty = true;
                return first.Info.Value;
            }

            _linkedList.Start = _linkedList.Start.Next;
            return first.Info.Value;
        }

        public double Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            Node<(int priority, double value)> first = _linkedList.Start;
            return first.Info.value;
        }

        public int IndexOf(double value)
        {
            int index = -1;
            if (IsEmpty)
                return index;

            foreach (var node in _linkedList)
            {
                index++;
                if (node.Info.Value == value)
                    return index;
            }

            return -1;
        }

        public double ReturnByIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Index out of bounds of PriorityQueue");

            int currentIndex = 0;
            double toReturn = 0;
            foreach (var node in _linkedList)
            {
                if (currentIndex == index)
                    toReturn = node.Info.Value;
            }

            return toReturn;
        }

        static IPriorityQueue<(int Priority, double Value)>
            IPriorityQueue<(int Priority, double Value)>.operator +(
            IPriorityQueue<(int Priority, double Value)> one,
            IPriorityQueue<(int Priority, double Value)> two)
        {
            if (one is null || two is null)
            {
                throw new ArgumentNullException("Argument is null");
            }

            var currentOne = one.Start;
            var currentTwo = two.Start;
            IPriorityQueue<(int Priority, double Value)> result = new PriorityQueue();

            while (currentOne is not null || currentTwo is not null)
            {
                if (currentOne is null)
                {
                    result.Enqueue(currentTwo.Info.Priority, currentTwo.Info.Value);
                    currentTwo = currentTwo.Next;
                    continue;
                }

                if (currentTwo is null)
                {
                    result.Enqueue(currentOne.Info.Priority, currentOne.Info.Value);
                    currentOne = currentOne.Next;
                    continue;
                }

                if (currentOne.Info.Priority <= currentTwo.Info.Priority)
                {
                    result.Enqueue(currentOne.Info.Priority, currentOne.Info.Value);
                    currentOne = currentOne.Next;
                }
                else
                {
                    result.Enqueue(currentTwo.Info.Priority, currentTwo.Info.Value);
                    currentTwo = currentTwo.Next;
                }
            }

            return result;
        }
    }
}
