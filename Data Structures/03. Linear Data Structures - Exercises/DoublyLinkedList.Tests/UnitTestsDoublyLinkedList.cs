using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoublyLinkedList.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    [TestClass]
    public class UnitTestsDoublyLinkedList
    {
        [TestMethod]
        public void AddFirst_EmptyList_ShouldAddElement()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.AddFirst(5);

            // Assert
            Assert.AreEqual(1, list.Count);
            
            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>(){ 5 });
        }

        [TestMethod]
        public void AddFirst_SeveralElements_ShouldAddElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.AddFirst(10);
            list.AddFirst(5);
            list.AddFirst(3);

            // Assert
            Assert.AreEqual(3, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 3, 5, 10 });
        }

        [TestMethod]
        public void AddLast_EmptyList_ShouldAddElement()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.AddLast(5);

            // Assert
            Assert.AreEqual(1, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 5 });
        }

        [TestMethod]
        public void AddLast_SeveralElements_ShouldAddElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(15);

            // Assert
            Assert.AreEqual(3, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 5, 10, 15 });
        }

        [TestMethod]
        public void RemoveFirst_OneElement_ShouldMakeListEmpty()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddLast(5);

            // Act
            var element = list.RemoveFirst();

            // Assert
            Assert.AreEqual(5, element);
            Assert.AreEqual(0, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFirst_EmptyList_ShouldThrowException()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            var element = list.RemoveFirst();
        }

        [TestMethod]
        public void RemoveFirst_SeveralElements_ShouldRemoveElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);

            // Act
            var element = list.RemoveFirst();

            // Assert
            Assert.AreEqual(5, element);
            Assert.AreEqual(2, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 6, 7 });
        }

        [TestMethod]
        public void RemoveLast_OneElement_ShouldMakeListEmpty()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddFirst(5);

            // Act
            var element = list.RemoveLast();

            // Assert
            Assert.AreEqual(5, element);
            Assert.AreEqual(0, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveLast_EmptyList_ShouldThrowException()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            var element = list.RemoveLast();
        }
        
        [TestMethod]
        public void RemoveLast_SeveralElements_ShouldRemoveElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddFirst(10);
            list.AddFirst(9);
            list.AddFirst(8);

            // Act
            var element = list.RemoveLast();

            // Assert
            Assert.AreEqual(10, element);
            Assert.AreEqual(2, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 8, 9 });
        }

        [TestMethod]
        public void ForEach_EmptyList_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            var items = new List<int>();
            list.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, new List<int>() { });
        }

        [TestMethod]
        public void ForEach_SingleElement_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddLast(5);

            // Act
            var items = new List<int>();
            list.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, new List<int>() { 5 });
        }

        [TestMethod]
        public void ForEach_MultipleElements_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<string>();
            list.AddLast("Five");
            list.AddLast("Six");
            list.AddLast("Seven");

            // Act
            var items = new List<string>();
            list.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, 
                new List<string>() { "Five", "Six", "Seven" });
        }

        [TestMethod]
        public void IEnumerable_Foreach_MultipleElements()
        {
            // Arrange
            var list = new DoublyLinkedList<string>();
            list.AddLast("Five");
            list.AddLast("Six");
            list.AddLast("Seven");

            // Act
            var items = new List<string>();
            foreach (var element in list)
            {
                items.Add(element);
            }

            // Assert
            CollectionAssert.AreEqual(items,
                new List<string>() { "Five", "Six", "Seven" });
        }

        [TestMethod]
        public void IEnumerable_NonGeneric_MultipleElements()
        {
            // Arrange
            var list = new DoublyLinkedList<object>();
            list.AddLast("Five");
            list.AddLast(6);
            list.AddLast(7.77);

            // Act
            var enumerator = ((IEnumerable)list).GetEnumerator();
            var items = new List<object>();
            while (enumerator.MoveNext())
            {
                items.Add(enumerator.Current);
            }

            // Assert
            CollectionAssert.AreEqual(items, new List<object>() { "Five", 6, 7.77 });
        }

        [TestMethod]
        public void ToArray_EmptyList_ShouldReturnEmptyArray()
        {
            // Arrange
            var list = new DoublyLinkedList<string>();

            // Act
            var arr = list.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr, new List<string>() { });
        }

        [TestMethod]
        public void ToArray_NonEmptyList_ShouldReturnArray()
        {
            // Arrange
            var list = new DoublyLinkedList<string>();
            list.AddLast("Five");
            list.AddLast("Six");
            list.AddLast("Seven");

            // Act
            var arr = list.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr,
                new string[] { "Five", "Six", "Seven" });
        }
    }
}
