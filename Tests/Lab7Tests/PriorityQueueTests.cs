﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Laba.DataStructures;
using Laba.DataStructures.Interfaces;

namespace Tests.Lab7Tests
{
    public class PriorityQueueTests
    {
        [Fact]
        public void Count_EmptyQueue_ReturnZero()
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();

            // Act

            //Assert
            Assert.Equal(0, priorityQueue.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        public void Count_NotEmptyQueue_ReturnNotZero(int count)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            int expectedCount = count;

            // Act
            for (int i = 0; i < count; i++)
            {
                priorityQueue.Enqueue(3, 1.3);
            }

            //Assert
            Assert.Equal(expectedCount, priorityQueue.Count);
        }

        [Fact]
        public void IsEmpty_EmptyQueue_ReturnTrue()
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();

            // Act

            //Assert
            Assert.True(priorityQueue.IsEmpty);
        }

        [Theory]
        [InlineData(1)]
        public void IsEmpty_NotEmptyQueue_ReturnFalse(int count)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();

            // Act
            for (int i = 0; i < count; i++)
            {
                priorityQueue.Enqueue(3, 1.3);
            }

            //Assert
            Assert.False(priorityQueue.IsEmpty);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-12)]
        public void Enqueue_AddElementWithInvalidPriority_ThrowsException(int priority)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();

            // Act

            //Assert
            Assert.Throws<ArgumentException>(() => priorityQueue.Enqueue(priority, 7));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        public void Enqueue_AddValidElements_AddCorrectNumberOfElements(int count)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();

            // Act
            for (int i = 0; i < count; i++)
            {
                priorityQueue.Enqueue(1, 7.5);
            }

            //Assert
            Assert.Equal(count, priorityQueue.Count);
        }

        [Theory]
        [InlineData("1,3", "3")]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", "3,5,4,6,1.3,6.44")]
        [InlineData("5,4/4,3/3,2/2,1", "1,2,3,4")]
        [InlineData("5,1.1/5,2.2/5,3.3/5,4.4", "1.1,2.2,3.3,4.4")]
        public void Enqueue_AddValidElements_AddElementsInCorrectOrder(string elemsString, string expected)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            IEnumerable<(int, double)> elems = elemsString.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );
            string actual;
            List<double> elementsFromPriorityQueue = new List<double>();

            // Act
            foreach (var elem in elems)
            {
                priorityQueue.Enqueue(elem.Item1, elem.Item2);
            }

            foreach (var item in priorityQueue)
            {
                elementsFromPriorityQueue.Add(item.Item2);
            }

            actual = string.Join(',', elementsFromPriorityQueue);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Peek_EmptyQueue_ThrowsInvalidOperationException()
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();

            // Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => priorityQueue.Peek());
        }

        [Theory]
        [InlineData("1,3", 3)]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", 3)]
        [InlineData("5,4/4,3/3,2/2,1", 1)]
        [InlineData("5,1.1/5,2.2/5,3.3/5,4.4", 1.1)]
        public void Peek_NonEmptyQueue_ReturnsFirstElement(string elemsString, double expected)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            IEnumerable<(int, double)> elems = elemsString.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );
            double actual;

            // Act
            foreach (var elem in elems)
            {
                priorityQueue.Enqueue(elem.Item1, elem.Item2);
            }

            actual = priorityQueue.Peek();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Dequeue_EmptyQueue_ThrowsInvalidOperationException()
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();

            // Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => priorityQueue.Dequeue());
        }

        [Theory]
        [InlineData("1,3", 3)]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", 3)]
        [InlineData("5,4/4,3/3,2/2,1", 1)]
        [InlineData("5,1.1/5,2.2/5,3.3/5,4.4", 1.1)]
        public void Dequeue_NonEmptyQueue_ReturnsFirstElement(string elemsString, double expected)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            IEnumerable<(int, double)> elems = elemsString.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );
            double actual;

            // Act
            foreach (var elem in elems)
            {
                priorityQueue.Enqueue(elem.Item1, elem.Item2);
            }

            actual = priorityQueue.Dequeue();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,3")]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6")]
        public void Dequeue_NonEmptyQueue_CountIsDecremented(string elemsString)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            IEnumerable<(int, double)> elems = elemsString.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );
            double countBefore;

            // Act
            foreach (var elem in elems)
            {
                priorityQueue.Enqueue(elem.Item1, elem.Item2);
            }
            countBefore = priorityQueue.Count;
            priorityQueue.Dequeue();

            //Assert
            Assert.Equal(countBefore, priorityQueue.Count + 1);
        }

        [Fact]
        public void MinElement_EmptyQueue_ThrowsInvalidOperationException()
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();

            // Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => priorityQueue.MinElement());
        }

        [Theory]
        [InlineData("1,3", 3)]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", 1.3)]
        [InlineData("5,1.1/5,2.2/5,3.3/5,4.4", 1.1)]
        public void MinElement_NonEmptyQueue_ReturnsMinElement(string elemsString, double expected)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            IEnumerable<(int, double)> elems = elemsString.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );
            double actual;

            // Act
            foreach (var elem in elems)
            {
                priorityQueue.Enqueue(elem.Item1, elem.Item2);
            }

            actual = priorityQueue.MinElement();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaxElement_EmptyQueue_ThrowsInvalidOperationException()
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();

            // Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => priorityQueue.MaxElement());
        }

        [Theory]
        [InlineData("1,3", 3)]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", 6.44)]
        [InlineData("5,1.1/5,2.2/5,3.3/5,4.4", 4.4)]
        public void MaxElement_NonEmptyQueue_ReturnsMaxElement(string elemsString, double expected)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            IEnumerable<(int, double)> elems = elemsString.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );
            double actual;

            // Act
            foreach (var elem in elems)
            {
                priorityQueue.Enqueue(elem.Item1, elem.Item2);
            }

            actual = priorityQueue.MaxElement();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IndexOf_EmptyQueue_ThrowsInvalidOperationException()
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();

            // Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => priorityQueue.IndexOf(12.3));
        }

        [Theory]
        [InlineData("1,3", 5, -1)]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", 123, -1)]
        public void IndexOf_ElementNotInQueue_ReturnsMinusOne(string elemsString, double value, int expected)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            IEnumerable<(int, double)> elems = elemsString.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );
            double actual;

            // Act
            foreach (var elem in elems)
            {
                priorityQueue.Enqueue(elem.Item1, elem.Item2);
            }

            actual = priorityQueue.IndexOf(value);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,3", 3, 0)]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", 1.3, 4)]
        public void IndexOf_ElementInQueue_ReturnsIndexOfElement(string elemsString, double value, int expected)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            IEnumerable<(int, double)> elems = elemsString.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );
            double actual;

            // Act
            foreach (var elem in elems)
            {
                priorityQueue.Enqueue(elem.Item1, elem.Item2);
            }

            actual = priorityQueue.IndexOf(value);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,3", -1)]
        [InlineData("1,3", 1)]
        [InlineData("1,3", 3)]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", 123)]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", -22)]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", -1)]
        public void ReturnByIndex_InvalidIndex_ThrowsIndexOutOfRangeException(string elemsString, int index)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            IEnumerable<(int, double)> elems = elemsString.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );

            // Act
            foreach (var elem in elems)
            {
                priorityQueue.Enqueue(elem.Item1, elem.Item2);
            }

            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => priorityQueue.ReturnByIndex(index));
        }

        [Theory]
        [InlineData("1,3", 0, 3)]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", 0, 3)]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", 4, 1.3)]
        public void ReturnByIndex_ValidIndex_ReturnsValueAtIndex(string elemsString, int index, double expected)
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            IEnumerable<(int, double)> elems = elemsString.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );
            double actual;

            // Act
            foreach (var elem in elems)
            {
                priorityQueue.Enqueue(elem.Item1, elem.Item2);
            }

            actual = priorityQueue.ReturnByIndex(index);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Plus_NullParameter_ThrowsArgumentNullException()
        {
            // Arrange
            PriorityQueue priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue(1, 3);
            priorityQueue.Enqueue(4, 3.2);
            priorityQueue.Enqueue(3, 12.5);

            // Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => priorityQueue + null);
            Assert.Throws<ArgumentNullException>(() => null + priorityQueue);
        }

        [Theory]
        [InlineData("1,3", "2,2", "3,2")]
        [InlineData("1,3/5,1.3/3,5/12,6.44/4,4/4,6", "7,1.01/10,2/12,4", "3,5,4,6,1.3,1.01,2,6.44,4")]
        public void Plus_ValidParameters_ReturnCorrectQueue(string one, string two, string expected)
        {
            // Arrange
            PriorityQueue priorityQueueOne = new PriorityQueue();
            PriorityQueue priorityQueueTwo = new PriorityQueue();
            PriorityQueue priorityQueueAdd = new PriorityQueue();
            IEnumerable<(int, double)> elemsOne = one.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );
            IEnumerable<(int, double)> elemsTwo = two.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    s => (int.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]),
                    double.Parse(s.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]))
                );
            string actual;

            // Act
            foreach (var elem in elemsOne)
            {
                priorityQueueOne.Enqueue(elem.Item1, elem.Item2);
            }
            
            foreach (var elem in elemsTwo)
            {
                priorityQueueTwo.Enqueue(elem.Item1, elem.Item2);
            }

            priorityQueueAdd = priorityQueueOne + priorityQueueTwo;
            actual = string.Join(',', priorityQueueAdd.Select(p => p.Value));

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
