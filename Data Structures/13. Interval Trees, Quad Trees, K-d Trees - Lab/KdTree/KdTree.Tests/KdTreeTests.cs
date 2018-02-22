using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class KdTreeTests
{
    [TestMethod]
    public void Initialize_ShouldBeEmpty()
    {
        KdTree tree = new KdTree();

        var actual = new List<Point2D>();
        tree.EachInOrder(actual.Add);

        var expected = new List<Point2D>();
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Insert_SinglePoint_TestRoot()
    {
        KdTree tree = new KdTree();
        tree.Insert(new Point2D(5, 5));

        var expected = tree.Root.Point;

        Assert.AreEqual(expected, new Point2D(5, 5));
    }

    [TestMethod]
    public void Insert_SinglePoint_TestAllElements()
    {
        KdTree tree = new KdTree();
        tree.Insert(new Point2D(5, 5));

        var actual = new List<Point2D>();
        tree.EachInOrder(actual.Add);

        var expected = new List<Point2D>()
        {
            new Point2D(5, 5),
        };

        CollectionAssert.AreEqual(expected, actual);
    }



    [TestMethod]
    public void Insert_MultiplePoints_TestContains()
    {
        KdTree tree = new KdTree();
        tree.Insert(new Point2D(5, 5));
        tree.Insert(new Point2D(3, 2));
        tree.Insert(new Point2D(2, 6));
        tree.Insert(new Point2D(8, 8));
        tree.Insert(new Point2D(8, 9));

        Assert.IsTrue(tree.Contains(new Point2D(5, 5)));
        Assert.IsTrue(tree.Contains(new Point2D(3, 2)));
        Assert.IsTrue(tree.Contains(new Point2D(2, 6)));
        Assert.IsTrue(tree.Contains(new Point2D(8, 8)));
        Assert.IsTrue(tree.Contains(new Point2D(8, 9)));
    }

    [TestMethod]
    public void Insert_MultiplePoints_TestInOrder()
    {
        KdTree tree = new KdTree();
        tree.Insert(new Point2D(5, 5));
        tree.Insert(new Point2D(3, 2));
        tree.Insert(new Point2D(2, 6));
        tree.Insert(new Point2D(8, 8));
        tree.Insert(new Point2D(8, 9));

        var actual = new List<Point2D>();
        tree.EachInOrder(actual.Add);

        var expected = new List<Point2D>()
        {
            new Point2D(3, 2),
            new Point2D(2, 6),
            new Point2D(5, 5),
            new Point2D(8, 8),
            new Point2D(8, 9), 
        };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Insert_Many_RandomSet()
    {
        var rnd = new Random();

        var tree = new KdTree();
        var set = new HashSet<Point2D>();

        for (int i = 0; i < 10000; i++)
        {
            var x = rnd.NextDouble();
            var y = rnd.NextDouble();
            var point = new Point2D(x, y);
            tree.Insert(point);
            set.Add(point);
        }

        foreach (var point in set)
        {
            Assert.IsTrue(tree.Contains(point));
        }
    }
}
