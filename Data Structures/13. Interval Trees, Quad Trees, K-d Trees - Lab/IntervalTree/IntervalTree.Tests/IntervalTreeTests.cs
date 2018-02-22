using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class IntervalTreeTests
{
    [TestMethod]
    public void InitialTree_ShouldBeEmpty()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();

        // Act
        var actual = new List<Interval>();
        tree.EachInOrder(actual.Add);

        // Assert
        var expected = new List<Interval>();
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Insert_Multiple()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        var expected = new List<Interval>()
        {
            new Interval(0, 1),
            new Interval(3, 41),
            new Interval(10, 15),
            new Interval(20, 36),
            new Interval(25, 30),
            new Interval(29, 99),
            new Interval(60, 72),
        };

        // Act
        var actual = new List<Interval>();
        tree.EachInOrder(actual.Add);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SearchAny_Hit_Root_Low()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        // Act
        // Assert
        Assert.AreEqual(new Interval(20, 36), tree.SearchAny(10, 25));
    }

    [TestMethod]
    public void SearchAny_Hit_Root_High()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        // Act
        // Assert
        Assert.AreEqual(new Interval(20, 36), tree.SearchAny(30, 40));
    }

    [TestMethod]
    public void SearchAny_Hit_Root_Center()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        // Act
        // Assert
        Assert.AreEqual(new Interval(20, 36), tree.SearchAny(25, 27));
    }

    [TestMethod]
    public void SearchAny_Hit_Root_Wrap()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        // Act
        // Assert
        Assert.AreEqual(new Interval(20, 36), tree.SearchAny(15, 40));
    }

    [TestMethod]
    public void SearchAny_Hit_Leaf_Low()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        // Act
        // Assert
        Assert.AreEqual(new Interval(0, 1), tree.SearchAny(-1, 1));
    }

    [TestMethod]
    public void SearchAny_Hit_Leaf_High()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        // Act
        // Assert
        Assert.AreEqual(new Interval(0, 1), tree.SearchAny(0, 2));
    }

    [TestMethod]
    public void SearchAny_Hit_Leaf_Center()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        // Act
        // Assert
        Assert.AreEqual(new Interval(0, 1), tree.SearchAny(0, 1));
    }

    [TestMethod]
    public void SearchAny_Hit_Leaf_Wrap()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        // Act
        // Assert
        Assert.AreEqual(new Interval(0, 1), tree.SearchAny(-1, 2));
    }

    [TestMethod]
    public void SearchAny_Miss_TouchingIntervals()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(1, 2);
        tree.Insert(2, 4);
        tree.Insert(3, 5);

        // Act
        // Assert
        Assert.IsNull(tree.SearchAny(5, 8));
    }

    [TestMethod]
    public void SearchAny_Miss_NonTouchingIntervals()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(1, 2);
        tree.Insert(2, 4);
        tree.Insert(3, 5);

        // Act
        // Assert
        Assert.IsNull(tree.SearchAny(12, 17));
    }

    [TestMethod]
    public void SearchAll_Miss_Left()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        var expected = new List<Interval>();

        // Act
        // Assert
        CollectionAssert.AreEqual(expected, new List<Interval>(tree.SearchAll(-2, -1)));
    }

    [TestMethod]
    public void SearchAll_Miss_Right()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        var expected = new List<Interval>();

        // Act
        // Assert
        CollectionAssert.AreEqual(expected, new List<Interval>(tree.SearchAll(120, 140)));
    }

    [TestMethod]
    public void SearchAll_Hit_Single()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(1, 2);
        tree.Insert(2, 4);
        tree.Insert(3, 5);

        var expected = new List<Interval>()
        {
            new Interval(3, 5)
        };

        // Act
        // Assert
        CollectionAssert.AreEqual(expected, new List<Interval>(tree.SearchAll(4, 6)));
    }

    [TestMethod]
    public void SearchAll_Hit_Two()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(1, 2);
        tree.Insert(2, 4);
        tree.Insert(3, 5);

        var expected = new List<Interval>()
        {
            new Interval(2, 4),
            new Interval(3, 5),
        };

        // Act
        // Assert
        CollectionAssert.AreEqual(expected, new List<Interval>(tree.SearchAll(3, 6)));
    }

    [TestMethod]
    public void SearchAll_Hit_Multiple()
    {
        // Arrange
        IntervalTree tree = new IntervalTree();
        tree.Insert(20, 36);
        tree.Insert(3, 41);
        tree.Insert(29, 99);
        tree.Insert(0, 1);
        tree.Insert(10, 15);
        tree.Insert(25, 30);
        tree.Insert(60, 72);

        var expected = new List<Interval>()
        {
            new Interval(3, 41),
            new Interval(10, 15),
            new Interval(20, 36),
            new Interval(25, 30),
            new Interval(29, 99),
        };

        // Act
        var actual = new List<Interval>(tree.SearchAll(10, 50));

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
