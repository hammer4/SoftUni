using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTestsBinarySearchTree
{
    [TestMethod]
    public void Insert_Single_TraverseInOrder()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(1);

        // Act
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void Insert_Multiple_TraverseInOrder()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        // Act
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 2, 3 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void Contains_ExistingElement_ShouldReturnTrue()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        // Act
        bool contains = bst.Contains(1);

        // Assert
        Assert.IsTrue(contains);
    }

    [TestMethod]
    public void Contains_NonExistingElement_ShouldReturnFalse()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        // Act
        bool contains = bst.Contains(5);

        // Assert
        Assert.IsFalse(contains);
    }

    [TestMethod]
    public void Insert_Multiple_DeleteMin_Should_Work_Correctly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(2);
        bst.Insert(1);
        bst.Insert(3);

        // Act
        bst.DeleteMin();
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 2, 3 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void DeleteMin_Empty_Tree_Should_Work_Correctly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        // Act
        bst.DeleteMin();
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void DeleteMin_One_Element_Should_Work_Correctly()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(1);

        // Act
        bst.DeleteMin();
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void Search_NonExistingElement_ShouldReturnEmptyTree()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        // Act
        BinarySearchTree<int> result = bst.Search(5);

        Assert.IsNull(result, null);
    }


    [TestMethod]
    public void Search_ExistingElement_ShouldReturnSubTree()
    {
        // Arrange
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        BinarySearchTree<int> result = bst.Search(5);
        List<int> nodes = new List<int>();
        result.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 3, 4, 5, 8, 9};
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void Range_ExistingElements_ShouldReturnCorrectElements()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        IEnumerable<int> result = bst.Range(4, 37);

        // Assert
        int[] expectedNodes = new int[] { 4, 5, 8, 9, 10, 37 };
        CollectionAssert.AreEqual(expectedNodes, result.ToArray());
    }

    [TestMethod]
    public void Range_ExistingElements_ShouldReturnCorrectCount()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        // Act
        IEnumerable<int> result = bst.Range(4, 37);

        // Assert
        int[] expectedNodes = new int[] { 4, 5, 8, 9, 10, 37 };
        Assert.AreEqual(expectedNodes.Length, result.ToArray().Length);
    }
}
