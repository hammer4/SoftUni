using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StronglyConnectedComponentsTests
{
    [TestMethod]
    public void FindSCC_WithSingleNode()
    {
        var graph = new List<int>[]
        {
                new List<int>() {},
        };

        var expected = new List<List<int>>
            {
                new List<int> { 0 }
            };

        var result = StronglyConnectedComponents.FindStronglyConnectedComponents(graph);
        result.ForEach(scc => scc.Sort());
        result = result.OrderBy(scc => scc.Count).ThenBy(scc => scc.First()).ToList();

        Assert.AreEqual(expected.Count, result.Count, "Incorrect amount of strongly connected components.");
        for (int i = 0; i < expected.Count; i++)
        {
            CollectionAssert.AreEqual(
                expected[i],
                result[i],
                $"Expected component to be [{string.Join(", ", expected[i])}], but was [{string.Join(", ", result[i])}].");
        }


    }

    [TestMethod]
    public void FindSCC_WithSingleComponentWithMultipleVertices()
    {
        var graph = new List<int>[]
        {
                new List<int>() {2},
                new List<int>() {2},
                new List<int>() {0, 1},
        };

        var expected = new List<List<int>>
            {
                new List<int> { 0, 1, 2 }
            };

        var result = StronglyConnectedComponents.FindStronglyConnectedComponents(graph);
        result.ForEach(scc => scc.Sort());
        result = result.OrderBy(scc => scc.Count).ThenBy(scc => scc.First()).ToList();

        Assert.AreEqual(expected.Count, result.Count, "Incorrect amount of strongly connected components.");
        for (int i = 0; i < expected.Count; i++)
        {
            CollectionAssert.AreEqual(
                expected[i],
                result[i],
                $"Expected component to be [{string.Join(", ", expected[i])}], but was [{string.Join(", ", result[i])}].");
        }
    }

    [TestMethod]
    public void FindSCC_WithCyclicComponent()
    {
        var graph = new List<int>[]
        {
                new List<int>() {1},
                new List<int>() {2},
                new List<int>() {0},
        };

        var expected = new List<List<int>>
            {
                new List<int> { 0, 1, 2 }
            };

        var result = StronglyConnectedComponents.FindStronglyConnectedComponents(graph);
        result.ForEach(scc => scc.Sort());
        result = result.OrderBy(scc => scc.Count).ThenBy(scc => scc.First()).ToList();

        Assert.AreEqual(expected.Count, result.Count, "Incorrect amount of strongly connected components.");
        for (int i = 0; i < expected.Count; i++)
        {
            CollectionAssert.AreEqual(
                expected[i],
                result[i],
                $"Expected component to be [{string.Join(", ", expected[i])}], but was [{string.Join(", ", result[i])}].");
        }
    }

    [TestMethod]
    public void FindSCC_WithThreeComponents()
    {
        var graph = new List<int>[]
        {
                new List<int>() {1, 3},         // children of node 0
                new List<int>() {},             // children of node 1
                new List<int>() {4, 7},         // children of node 2
                new List<int>() {2, 3, 4, 6},   // children of node 3
                new List<int>() {3, 5},         // children of node 4
                new List<int>() {1, 6},         // children of node 5
                new List<int>() {5},            // children of node 6
                new List<int>() {0, 2, 6},      // children of node 7
        };

        var expected = new List<List<int>>
            {
                new List<int> { 1 },
                new List<int> { 5, 6 },
                new List<int> { 0, 2, 3, 4, 7 },
            };

        var result = StronglyConnectedComponents.FindStronglyConnectedComponents(graph);
        result.ForEach(scc => scc.Sort());
        result = result.OrderBy(scc => scc.Count).ThenBy(scc => scc.First()).ToList();

        Assert.AreEqual(expected.Count, result.Count, "Incorrect amount of strongly connected components.");
        for (int i = 0; i < expected.Count; i++)
        {
            CollectionAssert.AreEqual(
                expected[i],
                result[i],
                $"Expected component to be [{string.Join(", ", expected[i])}], but was [{string.Join(", ", result[i])}].");
        }
    }

    [TestMethod]
    public void FindSCC_WithMultipleComponents()
    {
        var graph = new List<int>[]
        {
                new List<int>() {1, 11, 13}, // children of node 0
                new List<int>() {6},         // children of node 1
                new List<int>() {0},         // children of node 2
                new List<int>() {4},         // children of node 3
                new List<int>() {3, 6},      // children of node 4
                new List<int>() {13},        // children of node 5
                new List<int>() {0, 11},     // children of node 6
                new List<int>() {12},        // children of node 7
                new List<int>() {6, 11},     // children of node 8
                new List<int>() {0},         // children of node 9
                new List<int>() {4, 6, 10},  // children of node 10
                new List<int>() {},          // children of node 11
                new List<int>() {7},         // children of node 12
                new List<int>() {2, 9},      // children of node 13
        };

        var expected = new List<List<int>>
            {
                new List<int> { 5 },
                new List<int> { 8 },
                new List<int> { 10 },
                new List<int> { 11 },
                new List<int> { 3, 4 },
                new List<int> { 7, 12 },
                new List<int> { 0, 1, 2, 6, 9, 13 },
            };

        var result = StronglyConnectedComponents.FindStronglyConnectedComponents(graph);
        result.ForEach(scc => scc.Sort());
        result = result.OrderBy(scc => scc.Count).ThenBy(scc => scc.First()).ToList();

        Assert.AreEqual(expected.Count, result.Count, "Incorrect amount of strongly connected components.");
        for (int i = 0; i < expected.Count; i++)
        {
            CollectionAssert.AreEqual(
                expected[i],
                result[i],
                $"Expected component to be [{string.Join(", ", expected[i])}], but was [{string.Join(", ", result[i])}].");
        }
    }
}
