using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

[TestClass]
public class QuadTreeTests
{
    private const int OriginX = 0;
    private const int OriginY = 0;
    private const int WorldWidth = 200;
    private const int WorldHeight = 200;

    private QuadTree<TestBox> quadTree;

    [TestInitialize]
    public void TestInit()
    {
        this.quadTree = new QuadTree<TestBox>(WorldWidth, WorldHeight);
    }

    [TestMethod]
    public void Insert_ShouldIncreaseCount()
    {
        var items = new List<TestBox>
            {
                new TestBox(50, 50),
                new TestBox(50, 50),
                new TestBox(50, 50)
            };

        foreach (TestBox testBox in items)
        {
            this.quadTree.Insert(testBox);
        }

        Assert.AreEqual(items.Count, quadTree.Count);
    }

    [TestMethod]
    public void Report_FromEmptyQuadrant_ShouldReturnEmpty()
    {
        var items = new List<TestBox>
            {
                new TestBox(10, 0),
                new TestBox(110, 0),
                new TestBox(10, 110),
                new TestBox(50, 0)
            };

        // After 4 inserts root splits into 4 -> fourth quadrant is empty
        foreach (TestBox testBox in items)
        {
            this.quadTree.Insert(testBox);
        }

        var fourthQuadrant = GetSubquadrantBounds(4);

        var elements = this.quadTree.Report(fourthQuadrant);
        Assert.AreEqual(0, elements.Count);
    }

    [TestMethod]
    public void Report_FromNonEmptyQuadrant_ShouldReturnElements()
    {
        var items = new List<List<TestBox>>
            {
                new List<TestBox> { new TestBox(110, 0) }, // 1st
                new List<TestBox> { new TestBox(10, 0), new TestBox(50, 0) }, // 2nd
                new List<TestBox> { new TestBox(10, 110) } // 3rd
            };

        foreach (TestBox testBox in items.SelectMany(q => q))
        {
            this.quadTree.Insert(testBox);
        }

        var firstQuadrant = GetSubquadrantBounds(1);
        var elementsFirst = this.quadTree.Report(firstQuadrant);
        AssertCollectionEquality(elementsFirst, items[0]);

        var secondQuadrant = GetSubquadrantBounds(2);
        var elementsSecond = this.quadTree.Report(secondQuadrant);
        AssertCollectionEquality(elementsSecond, items[1]);

        var thirdQuadrant = GetSubquadrantBounds(3);
        var elementsThird = this.quadTree.Report(thirdQuadrant);
        AssertCollectionEquality(elementsThird, items[2]);
    }

    [TestMethod]
    public void ForeachDfs_ShouldCorrectlyDisplayDepth()
    {
        var items = Enumerable.Repeat(new TestBox(2, 2, 1, 1), 10000);
        foreach (TestBox testBox in items)
        {
            this.quadTree.Insert(testBox);
        }

        this.quadTree.ForEachDfs((elements, depth, quadrant) =>
        {
            Assert.AreEqual(this.quadTree.MaxDepth, depth);
        });
    }

    [TestMethod]
    public void Report_ManyRandomElements_ShouldCorrectlyReturnAllCandidateColliders()
    {
        const int ObjectsCount = 10000;

        var shepard = new TestBox(10, 20);
        var random = new Random();
        var list = new List<TestBox>();

        list.Add(shepard);
        quadTree.Insert(shepard);
        for (int i = 0; i < ObjectsCount; i++)
        {
            var x = random.Next(0, WorldWidth - 10);
            var y = random.Next(0, WorldHeight - 10);
            var obj = new TestBox(x, y);
            list.Add(obj);
            quadTree.Insert(obj);
        }

        var listCollisions = PerformCollisionSearchList(shepard, list)
            .OrderBy(e => e)
            .ToList();
        var quadTreeCollisions = PerformCollisionSearchQuadTree(shepard, quadTree)
            .OrderBy(e => e)
            .ToList();

        CollectionAssert.AreEqual(quadTreeCollisions, listCollisions);
    }

    static List<TestBox> PerformCollisionSearchList(
        TestBox obj, List<TestBox> list)
    {
        var result = new List<TestBox>();
        for (int i = 0; i < list.Count; i++)
        {
            if (obj.Bounds.Intersects(list[i].Bounds)
                && obj != list[i])
            {
                result.Add(list[i]);
            }
        }

        return result;
    }

    static List<TestBox> PerformCollisionSearchQuadTree(
        TestBox obj, QuadTree<TestBox> quadTree)
    {
        var result = new List<TestBox>();
        var collisionCandidates = quadTree.Report(obj.Bounds).ToList();
        for (int i = 0; i < collisionCandidates.Count; i++)
        {
            if (obj.Bounds.Intersects(collisionCandidates[i].Bounds)
                && obj != collisionCandidates[i])
            {
                result.Add(collisionCandidates[i]);
            }
        }

        return result;
    }

    private static void AssertCollectionEquality(
        IEnumerable<TestBox> collection1, IEnumerable<TestBox> collection2)
    {
        var sorted1 = collection1
            .OrderBy(e => e)
            .ToList();
        var sorted2 = collection2
            .OrderBy(e => e)
            .ToList();

        CollectionAssert.AreEqual(sorted1, sorted2);
    }

    private static Rectangle GetSubquadrantBounds(params int[] quadrants)
    {
        var x = OriginX;
        var y = OriginY;
        var width = WorldWidth;
        var height = WorldHeight;

        for (int i = 0; i < quadrants.Length; i++)
        {
            width /= 2;
            height /= 2;

            var quadrant = quadrants[i];
            if (quadrant == 1)
            {
                x += width;
            }
            else if (quadrant == 3)
            {
                y += height;
            }
            else if (quadrant == 4)
            {
                x += width;
                y += height;
            }
        }

        var bounds = new Rectangle(x, y, width, height);

        return bounds;
    }
}
