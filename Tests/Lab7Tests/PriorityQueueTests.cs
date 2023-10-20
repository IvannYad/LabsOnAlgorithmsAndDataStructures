﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba.DataStructures;

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
        public void Enqueue_AddElements_AddCorrectNumberOfElements(int count)
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
        public void Enqueue_AddElements_AddElementsInCorrectOrder(string elemsString, string expected)
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
    }
}
