using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class UnitTestsTopSort
{
    [TestMethod]
    public void TestTopSortAcyclicGraph6Vertices()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>()
        {
            { "A", new List<string>() { "B", "C" } },
            { "B", new List<string>() { "D", "E" } },
            { "C", new List<string>() { "F" } },
            { "D", new List<string>() { "C", "F" } },
            { "E", new List<string>() { "D" } },
            { "F", new List<string>() { } }
        };

        // Act
        var topSorter = new TopologicalSorter(graph);
        var sortedNodes = new List<string>(topSorter.TopSort());

        // Assert
        AssertTopologicallySorted(graph, sortedNodes);
    }

    [TestMethod]
    public void TestTopSortAcyclicGraph5Vertices()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>() {
            { "IDEs", new List<string>() { "variables", "loops" } },
            { "variables", new List<string>() { "conditionals", "loops", "bits" } },
            { "loops", new List<string>() { "bits" } },
            { "bits", new List<string>() { } },
            { "conditionals", new List<string>() { "loops" } }
        };

        // Act
        var topSorter = new TopologicalSorter(graph);
        var sortedNodes = new List<string>(topSorter.TopSort());

        // Assert
        AssertTopologicallySorted(graph, sortedNodes);
    }

    [TestMethod]
    public void TestTopSortGraph1Vertex()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>() {
            { "A", new List<string>() { } }
        };

        // Act
        var topSorter = new TopologicalSorter(graph);
        var sortedNodes = new List<string>(topSorter.TopSort());

        // Assert
        AssertTopologicallySorted(graph, sortedNodes);
    }

    [TestMethod]
    public void TestTopSortEmptyGraph()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>()
        {
        };

        // Act
        var topSorter = new TopologicalSorter(graph);
        var sortedNodes = new List<string>(topSorter.TopSort());

        // Assert
        AssertTopologicallySorted(graph, sortedNodes);
    }

    [TestMethod]
    public void TestTopSortAcyclicGraph8Vertices()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>() {
            { "H", new List<string>() { "G" } },
            { "G", new List<string>() { } },
            { "B", new List<string>() { "A" } },
            { "A", new List<string>() { } },
            { "F", new List<string>() { "B", "C", "E" } },
            { "C", new List<string>() { "A" } },
            { "E", new List<string>() { "C", "A" } },
            { "D", new List<string>() { "A", "B" } },
        };

        // Act
        var topSorter = new TopologicalSorter(graph);
        var sortedNodes = new List<string>(topSorter.TopSort());

        // Assert
        AssertTopologicallySorted(graph, sortedNodes);
    }

    [TestMethod]
    public void TestTopSortAcyclicGraph2Vertices()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>() {
            { "First", new List<string>() { "Second" } },
            { "Second", new List<string>() { } }
        };

        // Act
        var topSorter = new TopologicalSorter(graph);
        var sortedNodes = new List<string>(topSorter.TopSort());

        // Assert
        AssertTopologicallySorted(graph, sortedNodes);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestTopSortGraph2VerticesWithCycle()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>() {
            { "First", new List<string>() { "Second" } },
            { "Second", new List<string>() { "First" } }
        };

        // Act
        var topSorter = new TopologicalSorter(graph);
        var sortedNodes = new List<string>(topSorter.TopSort());

        // Assert
        AssertTopologicallySorted(graph, sortedNodes);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestTopSortGraph7VerticesWithCycle()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>()
        {
            { "A", new List<string>() { "B" } },
            { "B", new List<string>() { "C" } },
            { "C", new List<string>() { "D", "E" } },
            { "D", new List<string>() { "E" } },
            { "E", new List<string>() { "F", "C" } },
            { "F", new List<string>() { } },
            { "Z", new List<string>() { "A" } }
        };

        // Act
        var topSorter = new TopologicalSorter(graph);
        var sortedNodes = new List<string>(topSorter.TopSort());
    }

    [TestMethod]
    [Timeout(200)]
    public void TestPerformanceGraph1000Vertices()
    {
        // Arrange
        const int nodesCount = 1000;
        var graph = new Dictionary<string, List<string>>();
        for (int i = 0; i < nodesCount; i++)
        {
            graph["node" + i] = new List<string>();
        }
        for (int i = 0; i < nodesCount - 50; i++)
        {
            for (int c = 25; c < i % 50; c++)
            {
                graph["node" + i].Add("node" + (i + c));
            }
        }

        // Act
        var topSorter = new TopologicalSorter(graph);
        var sortedNodes = new List<string>(topSorter.TopSort());

        // Assert
        AssertTopologicallySorted(graph, sortedNodes);
    }

    private void AssertTopologicallySorted(
       Dictionary<string, List<string>> graph, List<string> sortedNodes)
    {
        foreach (var node in graph)
        {
            foreach (var childNode in node.Value)
            {
                int nodeIndex = sortedNodes.IndexOf(node.Key);
                int childIndex = sortedNodes.IndexOf(childNode);
                Assert.IsTrue(nodeIndex != -1,
                    "Node " + node.Key + " not found.");
                Assert.IsTrue(childIndex != -1,
                    "Node " + childNode + " not found.");
                Assert.IsTrue(nodeIndex < childIndex,
                    "Node " + node.Key + " should come before " + childNode);
            }
        }
    }
}
