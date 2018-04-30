using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ArticulationPointsTests
{
    [TestMethod]
    public void FindArticulationPoints_WithTwoNodes()
    {
        var graph = new List<int>[]
        {
                new List<int>() {1},      // children of node 0
                new List<int>() {0},      // children of node 1
        };

        var expected = new List<int> { };
        var result = ArticulationPoints.FindArticulationPoints(graph);

        CollectionAssert.AreEquivalent(expected, result, $"Expected [{string.Join(", ", expected)}], but was [{string.Join(", ", result)}].");
    }

    [TestMethod]
    public void FindArticulationPoints_WithSingleArticulationPoint()
    {
        var graph = new List<int>[]
        {
                new List<int>() {1},      // children of node 0
                new List<int>() {0, 2},   // children of node 1
                new List<int>() {1},      // children of node 2
        };

        var expected = new List<int> { 1 };
        var result = ArticulationPoints.FindArticulationPoints(graph);

        CollectionAssert.AreEquivalent(expected, result, $"Expected [{string.Join(", ", expected)}], but was [{string.Join(", ", result)}].");
    }

    [TestMethod]
    public void FindArticulationPoints_WithSmallGraph()
    {
        var graph = new List<int>[]
        {
                new List<int>() {1, 2},         // children of node 0
                new List<int>() {0, 5},         // children of node 1
                new List<int>() {0, 2, 3, 4},   // children of node 2
                new List<int>() {0, 2},         // children of node 3
                new List<int>() {2},            // children of node 4
                new List<int>() {1},            // children of node 5
        };

        var expected = new List<int> { 0, 1, 2 };
        var result = ArticulationPoints.FindArticulationPoints(graph);

        CollectionAssert.AreEquivalent(expected, result, $"Expected [{string.Join(", ", expected)}], but was [{string.Join(", ", result)}].");
    }

    [TestMethod]
    public void FindArticulationPoints_WithMediumGraph()
    {
        var graph = new List<int>[]
        {
                new List<int>() {1, 3, 5},         // children of node 0
                new List<int>() {0, 7},            // children of node 1
                new List<int>() {3, 6},            // children of node 2
                new List<int>() {0, 2, 7},         // children of node 3
                new List<int>() {6},               // children of node 4
                new List<int>() {0, 7},            // children of node 5
                new List<int>() {2, 4},            // children of node 6
                new List<int>() {1, 3, 5},         // children of node 7
        };

        var expected = new List<int> { 2, 3, 6 };
        var result = ArticulationPoints.FindArticulationPoints(graph);

        CollectionAssert.AreEquivalent(expected, result, $"Expected [{string.Join(", ", expected)}], but was [{string.Join(", ", result)}].");
    }

    [TestMethod]
    public void FindArticulationPoints_WithLargeGraph()
    {
        var graph = new List<int>[]
        {
                new List<int>() {1, 2, 6, 7, 9},      // children of node 0
                new List<int>() {0, 6},               // children of node 1
                new List<int>() {0, 7},               // children of node 2
                new List<int>() {4},                  // children of node 3
                new List<int>() {3, 6, 10},           // children of node 4
                new List<int>() {7},                  // children of node 5
                new List<int>() {0, 1, 4, 8, 10, 11}, // children of node 6
                new List<int>() {0, 2, 5, 9},         // children of node 7
                new List<int>() {6, 11},              // children of node 8
                new List<int>() {0, 7},               // children of node 9
                new List<int>() {4, 6},               // children of node 10
                new List<int>() {6, 8},               // children of node 11
        };

        var expected = new List<int> { 0, 4, 6, 7 };
        var result = ArticulationPoints.FindArticulationPoints(graph);

        CollectionAssert.AreEquivalent(expected, result, $"Expected [{string.Join(", ", expected)}], but was [{string.Join(", ", result)}].");
    }

    [TestMethod]
    public void FindArticulationPoints_WithMediumGraphWithNoArticulationPoints()
    {
        var graph = new List<int>[]
        {
                new List<int>() {3, 4, 6 },         // children of node 0
                new List<int>() {3, 5},             // children of node 1
                new List<int>() {3, 5},             // children of node 2
                new List<int>() {4, 6},             // children of node 3
                new List<int>() {3, 6},             // children of node 4
                new List<int>() {3, 6},             // children of node 5
                new List<int>() {0, 5},             // children of node 6
        };

        var expected = new List<int> { };
        var result = ArticulationPoints.FindArticulationPoints(graph);

        CollectionAssert.AreEquivalent(expected, result, $"Expected [{string.Join(", ", expected)}], but was [{string.Join(", ", result)}].");
    }

    [TestMethod]
    public void FindArticulationPoints_WithSingleComponentCentralPoint()
    {
        var graph = new List<int>[]
        {
                new List<int>() {1, 3},             // children of node 0
                new List<int>() {2, 4},             // children of node 1
                new List<int>() {1, 3},             // children of node 2
                new List<int>() {0, 2, 4},          // children of node 3
                new List<int>() {1, 3}              // children of node 4
        };

        var expected = new List<int> { };
        var result = ArticulationPoints.FindArticulationPoints(graph);

        CollectionAssert.AreEquivalent(expected, result, $"Expected [{string.Join(", ", expected)}], but was [{string.Join(", ", result)}].");
    }
}
