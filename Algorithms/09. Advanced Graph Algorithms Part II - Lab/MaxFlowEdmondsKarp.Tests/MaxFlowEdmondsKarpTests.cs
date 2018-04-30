using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MaxFlowEdmondsKarpTests
{
    [TestMethod]
    public void FindMaxFlow_WithCrossGraph()
    {
        var graph = new int[][]
        {
                new int[] { 0, 1000, 1000, 0 },
                new int[] { 0, 0, 1, 1000 },
                new int[] { 0, 0, 0, 1000 },
                new int[] { 0, 0, 0, 0 },
        };
        var expected = 2000;
        var maxFlow = EdmondsKarp.FindMaxFlow(graph);

        Assert.AreEqual(expected, maxFlow, $"Expected {expected}, but was {maxFlow}.");
    }

    [TestMethod]
    public void FindMaxFlow_WithSmallGraph()
    {
        var graph = new int[][]
        {
                new int[] { 0, 10, 10, 0, 0, 0 },
                new int[] { 0, 0, 2, 4, 8, 0},
                new int[] { 0, 0, 0, 0, 9, 0},
                new int[] { 0, 0, 0, 0, 0, 10 },
                new int[] { 0, 0, 0, 6, 0, 10 },
                new int[] { 0, 0, 0, 0, 0, 0 },
        };

        var expected = 19;
        var maxFlow = EdmondsKarp.FindMaxFlow(graph);

        Assert.AreEqual(expected, maxFlow, $"Expected {expected}, but was {maxFlow}.");
    }

    [TestMethod]
    public void FindMaxFlow_WithMediumGraph()
    {
        var graph = new int[][]
        {
                new int[] { 0, 6, 15, 5, 0, 0, 0, 0 },
                new int[] { 0, 0, 7, 0, 8, 0, 0, 3},
                new int[] { 0, 0, 0, 9, 9, 13, 0, 0},
                new int[] { 0, 0, 0, 3, 17, 10, 5, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 11, 8},
                new int[] { 0, 0, 0, 0, 0, 0, 7, 12},
                new int[] { 0, 0, 0, 0, 0, 0, 0, 14},
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0},
        };

        var expected = 26;
        var maxFlow = EdmondsKarp.FindMaxFlow(graph);

        Assert.AreEqual(expected, maxFlow, $"Expected {expected}, but was {maxFlow}.");
    }


    [TestMethod]
    public void FindMaxFlow_WithMediumGraphWithBackwardsEdges()
    {
        var graph = new int[][]
        {
                new int[] { 0, 0, 3, 5, 17, 0, 5, 0 },
                new int[] { 0, 0, 2, 13, 0, 0, 7, 0},
                new int[] { 0, 6, 0, 9, 3, 13, 0, 0},
                new int[] { 0, 0, 3, 0, 17, 10, 5, 0 },
                new int[] { 0, 15, 0, 8, 0, 6, 6, 9},
                new int[] { 0, 0, 22, 0, 3, 0, 7, 10},
                new int[] { 0, 5, 0, 9, 4, 13, 0, 5},
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0},
        };

        var expected = 24;
        var maxFlow = EdmondsKarp.FindMaxFlow(graph);

        Assert.AreEqual(expected, maxFlow, $"Expected {expected}, but was {maxFlow}.");
    }

    [TestMethod]
    public void FindMaxFlow_WithLargeGraph()
    {
        var graph = new int[][]
        {
                new int[]{ 0,  0,  0,  0,  0,  0, 30,  0, 22,  0,  0,  0 }, // 0
                new int[]{ 0,  0,  0,  0, 20,  0,  0, 26,  0, 25,  0,  6 }, // 1
                new int[]{ 0,  0,  0,  0,  0,  0,  0, 15, 14,  0,  0,  9 }, // 2
                new int[]{ 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  7,  0 }, // 3
                new int[]{ 0, 20,  0,  0,  0,  5, 17,  0,  0,  0,  0, 11 }, // 4
                new int[]{ 0,  0,  0,  0,  5,  0,  6,  0,  3,  0,  0, 33 }, // 5
                new int[]{30,  0,  0,  0, 17,  6,  0,  0,  0,  0,  0,  0 }, // 6
                new int[]{ 0, 26, 15,  0,  0,  0,  0,  0,  0, 23,  0, 20 }, // 7
                new int[]{22,  0, 14,  0,  0,  3,  0,  0,  0,  0,  0,  0 }, // 8
                new int[]{ 0, 25,  0,  0,  0,  0,  0, 23,  0,  0,  0,  0 }, // 9
                new int[]{ 0,  0,  0,  7,  0,  0,  0,  0,  0,  0,  0,  0 }, // 10
                new int[]{ 0,  6,  9,  0, 11, 33,  0, 20,  0,  0,  0,  0 }, // 11
        };

        var expected = 40;
        var maxFlow = EdmondsKarp.FindMaxFlow(graph);

        Assert.AreEqual(expected, maxFlow, $"Expected {expected}, but was {maxFlow}.");
    }

    [TestMethod]
    public void FindMaxFlow_WithLargeGraphWithBackwardsEdges()
    {
        var graph = new int[][]
        {
                new int[] { 0, 13, 55, 8, 0, 13, 0, 0, 15, 0, 5, 0, 0 },
                new int[] { 0, 0, 155, 13, 21, 0, 0, 0, 14, 0, 35, 0, 0 },
                new int[] { 0, 3, 0, 44, 0, 15, 0, 0, 47, 0, 56, 0, 14 },
                new int[] { 0, 77, 0, 0, 0, 71, 28, 90, 99, 5, 0, 76, 0 },
                new int[] { 0, 0, 15, 7, 0, 64, 3, 0, 15, 0, 65, 0, 43 },
                new int[] { 0, 23, 0, 5, 17, 0, 5, 0, 51, 3, 86, 0, 0 },
                new int[] { 0, 33, 33, 0, 0, 7, 0, 13, 0, 6, 17, 8, 34 },
                new int[] { 0, 0, 0, 0, 0, 0, 5, 0, 5, 5, 5, 5, 5 },
                new int[] { 0, 5, 0, 0, 27, 13, 34, 0, 21, 57, 42, 0, 71 },
                new int[] { 0, 287, 15, 31, 49, 0, 70, 0, 13, 0, 99, 13, 0 },
                new int[] { 0, 0, 44, 1, 17, 0, 5, 0, 15, 0, 0, 29, 0 },
                new int[] { 0, 44, 4, 13, 19, 14, 0, 0, 34, 0, 12, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };

        var expected = 109;
        var maxFlow = EdmondsKarp.FindMaxFlow(graph);

        Assert.AreEqual(expected, maxFlow, $"Expected {expected}, but was {maxFlow}.");
    }
}
