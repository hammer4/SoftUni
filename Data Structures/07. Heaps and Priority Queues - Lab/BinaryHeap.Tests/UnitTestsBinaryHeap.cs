using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BinaryHeap.Tests
{
    [TestClass]
    public class TestBinaryHeap
    {
        [TestMethod]
        public void Insert_Single_TestCount()
        {
            // Arrange
            var heap = new BinaryHeap<int>();

            // Act
            heap.Insert(3);

            // Assert
            Assert.AreEqual(1, heap.Count, "Wrong count");
        }

        [TestMethod]
        public void Insert_Single_TestPeek()
        {
            // Arrange
            var heap = new BinaryHeap<int>();

            // Act
            heap.Insert(3);

            // Assert
            Assert.AreEqual(3, heap.Peek(), "Wrong element");
        }

        [TestMethod]
        public void Insert_Multiple_TestCount()
        {
            // Arrange
            var heap = new BinaryHeap<int>();

            // Act
            // Assert
            heap.Insert(3);
            Assert.AreEqual(1, heap.Count, "Wrong count");

            heap.Insert(5);
            Assert.AreEqual(2, heap.Count, "Wrong count");

            heap.Insert(6);
            Assert.AreEqual(3, heap.Count, "Wrong count");
        }

        [TestMethod]
        public void Insert_Multiple_TestPeek()
        {
            // Arrange
            var heap = new BinaryHeap<int>();

            // Act
            // Assert
            heap.Insert(3);
            Assert.AreEqual(3, heap.Peek(), "Wrong element");

            heap.Insert(5);
            Assert.AreEqual(5, heap.Peek(), "Wrong element");

            heap.Insert(2);
            Assert.AreEqual(5, heap.Peek(), "Wrong element");

            heap.Insert(1);
            Assert.AreEqual(5, heap.Peek(), "Wrong element");

            heap.Insert(7);
            Assert.AreEqual(7, heap.Peek(), "Wrong element");

            heap.Insert(8);
            Assert.AreEqual(8, heap.Peek(), "Wrong element");
        }

        [TestMethod]
        public void Pull_Single_TestCount()
        {
            // Arrange
            var heap = new BinaryHeap<int>();

            // Act
            heap.Insert(3);
            heap.Insert(5);
            heap.Pull();

            // Assert
            Assert.AreEqual(1, heap.Count, "Wrong count");
        }

        [TestMethod]
        public void Pull_Single_TestElement()
        {
            // Arrange
            var heap = new BinaryHeap<int>();

            // Act
            heap.Insert(3);

            // Assert
            Assert.AreEqual(3, heap.Pull(), "Wrong element");
        }

        [TestMethod]
        public void Pull_Multiple_TestCount()
        {
            // Arrange
            var heap = new BinaryHeap<int>();

            // Act
            heap.Insert(5);
            heap.Insert(3);
            heap.Insert(1);

            // Assert
            Assert.AreEqual(5, heap.Pull(), "Wrong element");
            Assert.AreEqual(3, heap.Pull(), "Wrong element");
            Assert.AreEqual(1, heap.Pull(), "Wrong element");
            Assert.AreEqual(0, heap.Count, "Wrong count");
        }

        [TestMethod]
        public void Pull_Multiple_TestElements()
        {
            // Arrange
            var heap = new BinaryHeap<int>();

            // Act
            heap.Insert(3);
            heap.Insert(5);
            heap.Insert(6);
            heap.Insert(7);

            // Assert
            Assert.AreEqual(7, heap.Pull(), "Wrong element");
            Assert.AreEqual(6, heap.Pull(), "Wrong element");
            Assert.AreEqual(5, heap.Pull(), "Wrong element");
            Assert.AreEqual(3, heap.Pull(), "Wrong element");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pull_EmptyHeap()
        {
            // Arrange
            var heap = new BinaryHeap<int>();

            // Act
            heap.Pull();
        }
    }
}
