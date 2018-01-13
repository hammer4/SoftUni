using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTestsCircularQueue
{
    [TestMethod]
    public void Enqueue_EmptyQueue_ShouldAddElement()
    {
        // Arrange
        CircularQueue<int> queue = new CircularQueue<int>();

        // Act
        queue.Enqueue(5);

        // Assert
        Assert.AreEqual(1, queue.Count);
    }

    [TestMethod]
    public void EnqueueDeque_ShouldWorkCorrectly()
    {
        // Arrange
        CircularQueue<string> queue = new CircularQueue<string>();
        string element = "some value";

        // Act
        queue.Enqueue(element);
        string elementFromQueue = queue.Dequeue();

        // Assert
        Assert.AreEqual(0, queue.Count);
        Assert.AreEqual(element, elementFromQueue);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Dequeue_EmptyQueue_ThrowsException()
    {
        // Arrange
        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Dequeue();
    }

    [TestMethod]
    public void EnqueueDequeue100Elements_ShouldWorkCorrectly()
    {
        // Arrange
        CircularQueue<int> queue = new CircularQueue<int>();
        int numberOfElements = 1000;

        // Act
        for (int i = 0; i < numberOfElements; i++)
        {
            queue.Enqueue(i);
        }

        // Assert
        for (int i = 0; i < numberOfElements; i++)
        {
            Assert.AreEqual(numberOfElements - i, queue.Count);
            int element = queue.Dequeue();
            Assert.AreEqual(i, element);
            Assert.AreEqual(numberOfElements - i - 1, queue.Count);
        }
    }

    [TestMethod]
    public void CircularQueue_EnqueueDequeueManyChunks_ShouldWorkCorrectly()
    {
        // Arrange
        CircularQueue<int> queue = new CircularQueue<int>();
        int chunks = 100;

        // Act & Assert in a loop
        int value = 1;
        for (int i = 0; i < chunks; i++)
        {
            Assert.AreEqual(0, queue.Count);
            int chunkSize = i + 1;
            for (int counter = 0; counter < chunkSize; counter++)
            {
                Assert.AreEqual(value - 1, queue.Count);
                queue.Enqueue(value);
                Assert.AreEqual(value, queue.Count);
                value++;
            }
            for (int counter = 0; counter < chunkSize; counter++)
            {
                value--;
                Assert.AreEqual(value, queue.Count);
                queue.Dequeue();
                Assert.AreEqual(value - 1, queue.Count);
            }
            Assert.AreEqual(0, queue.Count);
        }
    }

    [TestMethod]
    public void Enqueue500Elements_ToArray_ShouldWorkCorrectly()
    {
        // Arrange
        int[] array = Enumerable.Range(1, 500).ToArray();
        CircularQueue<int> queue = new CircularQueue<int>();

        // Act
        for (int i = 0; i < array.Length; i++)
        {
            queue.Enqueue(array[i]);
        }
        int[] arrayFromQueue = queue.ToArray();

        // Assert
        CollectionAssert.AreEqual(array, arrayFromQueue);
    }

    [TestMethod]
    public void InitialCapacity1_EnqueueDequeue20Elements_ShouldWorkCorrectly()
    {
        // Arrange
        int elementsCount = 20;
        int initialCapacity = 1;

        // Act
        CircularQueue<int> queue = new CircularQueue<int>(initialCapacity);
        for (int i = 0; i < elementsCount; i++)
        {
            queue.Enqueue(i);
        }

        // Assert
        Assert.AreEqual(elementsCount, queue.Count);
        for (int i = 0; i < elementsCount; i++)
        {
            int elementFromQueue = queue.Dequeue();
            Assert.AreEqual(i, elementFromQueue);
        }
        Assert.AreEqual(0, queue.Count);
    }
}