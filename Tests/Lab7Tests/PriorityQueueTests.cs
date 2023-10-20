using System;
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
    }
}
