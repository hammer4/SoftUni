using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class AVLTests
{
    [TestMethod]
    public void TraverseInOrder_AfterSingleInsert()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        avl.Insert(1);

        // Act
        List<int> nodes = new List<int>();
        avl.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void TraverseInOrder_AfterMultipleInserts()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        avl.Insert(2);
        avl.Insert(1);
        avl.Insert(3);

        // Act
        List<int> nodes = new List<int>();
        avl.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 2, 3 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void Contains_ExistingElement_ShouldReturnTrue()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        avl.Insert(2);
        avl.Insert(1);
        avl.Insert(3);

        // Act
        // Assert
        Assert.IsTrue(avl.Contains(1));
        Assert.IsTrue(avl.Contains(2));
        Assert.IsTrue(avl.Contains(3));
    }

    [TestMethod]
    public void Contains_NonExistingElement_ShouldReturnFalse()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        avl.Insert(2);
        avl.Insert(1);
        avl.Insert(3);

        // Act
        bool contains = avl.Contains(5);

        // Assert
        Assert.IsFalse(contains);
    }

    [TestMethod]
    public void Height_RootRight()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        avl.Insert(1);
        avl.Insert(2);

        // Act
        // Assert
        Assert.AreEqual(2, avl.Root.Height);
        Assert.AreEqual(1, avl.Root.Right.Height);
    }

    [TestMethod]
    public void Height_RootLeft()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        avl.Insert(2);
        avl.Insert(1);

        // Act
        // Assert
        Assert.AreEqual(2, avl.Root.Height);
        Assert.AreEqual(1, avl.Root.Left.Height);
    }

    [TestMethod]
    public void Height_RootLeftRight()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        avl.Insert(2);
        avl.Insert(1);
        avl.Insert(3);

        // Act
        // Assert
        Assert.AreEqual(2, avl.Root.Height);
        Assert.AreEqual(1, avl.Root.Left.Height);
        Assert.AreEqual(1, avl.Root.Right.Height);
    }

    [TestMethod]
    public void Rebalance_RootShouldHaveHeightTwo()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        avl.Insert(1);
        avl.Insert(2);
        avl.Insert(3);

        // Assert
        Assert.AreEqual(2, avl.Root.Height);
    }

    [TestMethod]
    public void Rebalance_TestHeightOneNodes()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        for (int i = 1; i < 10; i++)
        {
            avl.Insert(i);
        }

        // Assert
        Assert.AreEqual(1, avl.Root.Left.Left.Height); // 1
        Assert.AreEqual(1, avl.Root.Left.Right.Height); // 3
        Assert.AreEqual(1, avl.Root.Right.Left.Height); // 5
        Assert.AreEqual(1, avl.Root.Right.Right.Left.Height); // 7
        Assert.AreEqual(1, avl.Root.Right.Right.Right.Height); // 9
    }

    [TestMethod]
    public void Rebalance_TestHeightTwoNodes()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        for (int i = 1; i < 10; i++)
        {
            avl.Insert(i);
        }

        // Assert
        Assert.AreEqual(2, avl.Root.Left.Height); // 2
        Assert.AreEqual(2, avl.Root.Right.Right.Height); // 8
    }

    [TestMethod]
    public void Rebalance_TestHeightThreeNodes()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        for (int i = 1; i < 10; i++)
        {
            avl.Insert(i);
        }

        // Assert
        Assert.AreEqual(3, avl.Root.Right.Height); // 6
    }

    [TestMethod]
    public void Rebalance_TestHeightFourNodes()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        for (int i = 1; i < 10; i++)
        {
            avl.Insert(i);
        }

        // Assert
        Assert.AreEqual(4, avl.Root.Height); // 4
    }

    [TestMethod]
    public void Rebalance_SingleRight()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();

        // Act
        avl.Insert(3);
        avl.Insert(2);
        avl.Insert(1);

        // Assert
        Assert.AreEqual(2, avl.Root.Value);
    }

    [TestMethod]
    public void Rebalance_SingleLeft()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();

        // Act
        avl.Insert(1);
        avl.Insert(2);
        avl.Insert(3);

        // Assert
        Assert.AreEqual(2, avl.Root.Value);
    }

    [TestMethod]
    public void Rebalance_DoubleRight()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();

        // Act
        avl.Insert(5);
        avl.Insert(2);
        avl.Insert(4);

        // Assert
        Assert.AreEqual(4, avl.Root.Value);
        Assert.AreEqual(2, avl.Root.Height);
        Assert.AreEqual(1, avl.Root.Left.Height);
        Assert.AreEqual(1, avl.Root.Right.Height);
    }

    [TestMethod]
    public void Rebalance_DoubleLeft()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();

        // Act
        avl.Insert(5);
        avl.Insert(7);
        avl.Insert(6);

        // Assert
        Assert.AreEqual(6, avl.Root.Value);
        Assert.AreEqual(2, avl.Root.Height);
        Assert.AreEqual(1, avl.Root.Left.Height);
        Assert.AreEqual(1, avl.Root.Right.Height);
    }

    [TestMethod, Timeout(400)]
    public void Performance_Insert_Contains()
    {
        var avl = new AVL<int>();

        for (int i = 0; i < 100000; i++)
        {
            avl.Insert(i);
        }

        for (int i = 0; i < 100000; i++)
        {
            Assert.IsTrue(avl.Contains(i));
        }
    }

    [TestMethod]
    public void Height_DeleteRoot()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        for (int i = 1; i < 10; i++)
        {
            avl.Insert(i);
        }

        avl.Delete(4);

        var root = avl.Root;

        // Assert
        Assert.AreEqual(5, root.Value);
        Assert.AreEqual(4, root.Height);

        // Nodes of height 1
        Assert.AreEqual(1, root.Left.Left.Height); // 1
        Assert.AreEqual(1, root.Left.Right.Height); // 3
        Assert.AreEqual(1, root.Right.Left.Right.Height); // 7
        Assert.AreEqual(1, root.Right.Right.Height); // 9

        // Nodes of height 2
        Assert.AreEqual(2, root.Left.Height); // 2
        Assert.AreEqual(2, root.Right.Left.Height); //6

        // Nodes of height 3
        Assert.AreEqual(3, root.Right.Height); // 8

        // Nodes of height 4
        Assert.AreEqual(4, root.Height); // 5
    }

    [TestMethod]
    public void Height_DeleteMultiple()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        for (int i = 1; i < 10; i++)
        {
            avl.Insert(i);
        }

        avl.Delete(4);
        avl.Delete(2);
        avl.Delete(1);

        var root = avl.Root;

        // Assert
        Assert.AreEqual(6, root.Value);
        Assert.AreEqual(3, root.Height);

        // Nodes of height 1
        Assert.AreEqual(3, root.Left.Left.Value);
        Assert.AreEqual(1, root.Left.Left.Height); // 3

        Assert.AreEqual(7, root.Right.Left.Value);
        Assert.AreEqual(1, root.Right.Left.Height); // 7

        Assert.AreEqual(9, root.Right.Right.Value);
        Assert.AreEqual(1, root.Right.Right.Height); // 9

        // Nodes of height 2
        Assert.AreEqual(5, root.Left.Value);
        Assert.AreEqual(2, root.Left.Height); // 5

        Assert.AreEqual(8, root.Right.Value);
        Assert.AreEqual(2, root.Right.Height); // 8
    }

    [TestMethod]
    public void DeleteMin_AfterMultipleInserts()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        avl.Insert(2);
        avl.Insert(1);
        avl.Insert(3);

        // Act
        avl.DeleteMin();
        List<int> nodes = new List<int>();
        avl.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 2, 3 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void DeleteMin_Empty_Tree_Should_Work_Correctly()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();

        // Act
        avl.DeleteMin();
        List<int> nodes = new List<int>();
        avl.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void DeleteMin_One_Element()
    {
        // Arrange
        AVL<int> avl = new AVL<int>();
        avl.Insert(1);

        // Act
        avl.DeleteMin();
        List<int> nodes = new List<int>();
        avl.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void Delete_LeftLeaf()
    {
        AVL<int> avl = new AVL<int>();

        avl.Insert(5);
        avl.Insert(3);
        avl.Insert(1);
        avl.Insert(4);
        avl.Insert(8);
        avl.Insert(9);

        // Act
        avl.Delete(1);
        List<int> result = new List<int>();
        avl.EachInOrder(result.Add);

        // Assert
        int[] expectedNodes = new int[] { 3, 4, 5, 8, 9 };
        CollectionAssert.AreEqual(expectedNodes, result.ToArray());
    }

    [TestMethod]
    public void Delete_RightLeaf()
    {
        AVL<int> avl = new AVL<int>();

        avl.Insert(5);
        avl.Insert(3);
        avl.Insert(1);
        avl.Insert(4);
        avl.Insert(8);
        avl.Insert(9);

        // Act
        avl.Delete(4);
        List<int> result = new List<int>();
        avl.EachInOrder(result.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 3, 5, 8, 9 };
        CollectionAssert.AreEqual(expectedNodes, result.ToArray());
    }

    [TestMethod]
    public void Delete_NodeWithRightChild()
    {
        AVL<int> avl = new AVL<int>();

        avl.Insert(5);
        avl.Insert(3);
        avl.Insert(1);
        avl.Insert(4);
        avl.Insert(8);
        avl.Insert(9);

        // Act
        avl.Delete(8);
        List<int> result = new List<int>();
        avl.EachInOrder(result.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 3, 4, 5, 9 };
        CollectionAssert.AreEqual(expectedNodes, result.ToArray());
    }

    [TestMethod]
    public void Delete_NodeWithLeftChild()
    {
        AVL<int> avl = new AVL<int>();

        avl.Insert(5);
        avl.Insert(3);
        avl.Insert(1);
        avl.Insert(4);
        avl.Insert(8);
        avl.Insert(9);

        // Act
        avl.Delete(4);
        avl.Delete(3);
        List<int> result = new List<int>();
        avl.EachInOrder(result.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 5, 8, 9 };
        CollectionAssert.AreEqual(expectedNodes, result.ToArray());
    }

    [TestMethod]
    public void Delete_NodeWithTwoChildren()
    {
        AVL<int> avl = new AVL<int>();

        avl.Insert(5);
        avl.Insert(3);
        avl.Insert(1);
        avl.Insert(4);
        avl.Insert(8);
        avl.Insert(9);

        // Act
        avl.Delete(3);
        List<int> result = new List<int>();
        avl.EachInOrder(result.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 4, 5, 8, 9 };
        CollectionAssert.AreEqual(expectedNodes, result.ToArray());
    }

    [TestMethod]
    public void Delete_Root()
    {
        AVL<int> avl = new AVL<int>();

        avl.Insert(5);
        avl.Insert(3);
        avl.Insert(1);
        avl.Insert(4);
        avl.Insert(8);
        avl.Insert(9);

        // Act
        avl.Delete(5);
        List<int> result = new List<int>();
        avl.EachInOrder(result.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 3, 4, 8, 9 };
        CollectionAssert.AreEqual(expectedNodes, result.ToArray());
    }

    [TestMethod]
    public void Delete_Root_EmptyTree()
    {
        AVL<int> avl = new AVL<int>();

        // Act
        avl.Delete(5);
        List<int> result = new List<int>();
        avl.EachInOrder(result.Add);

        // Assert
        int[] expectedNodes = new int[] { };
        CollectionAssert.AreEqual(expectedNodes, result.ToArray());
    }

    [TestMethod]
    public void Delete_Root_SingleElement()
    {
        AVL<int> avl = new AVL<int>();
        avl.Insert(5);

        // Act
        avl.Delete(5);
        List<int> result = new List<int>();
        avl.EachInOrder(result.Add);

        // Assert
        int[] expectedNodes = new int[] { };
        CollectionAssert.AreEqual(expectedNodes, result.ToArray());
    }
}
