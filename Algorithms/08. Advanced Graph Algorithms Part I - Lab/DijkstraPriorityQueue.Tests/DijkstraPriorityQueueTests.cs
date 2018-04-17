using System.Collections.Generic;

namespace Dijkstra.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DijkstraPriorityQueueTests
    {
        private static Dictionary<int, Node> nodes;

        private static Dictionary<Node, Dictionary<Node, int>> Graph;

        [TestInitialize]
        public void Initialize()
        {
            nodes = new Dictionary<int, Node>()
            {
                {0, new Node(0)},
                {1, new Node(1)},
                {2, new Node(2)},
                {3, new Node(3)},
                {4, new Node(4)},
                {5, new Node(5)},
                {6, new Node(6)},
                {7, new Node(7)},
                {8, new Node(8)},
                {9, new Node(9)},
                {10, new Node(10)},
                {11, new Node(11)}
            };
            Graph = new Dictionary<Node, Dictionary<Node, int>>()
            {
                {nodes[0], new Dictionary<Node,int>(){{nodes[6], 10}, {nodes[8], 12}}},
                {nodes[1], new Dictionary<Node,int>(){ {nodes[4], 20}, {nodes[7], 26}, {nodes[9], 5}, {nodes[11], 6}}},
                {nodes[2], new Dictionary<Node,int>() { {nodes[7], 15}, {nodes[8], 14}, {nodes[11], 9}}},
                {nodes[3], new Dictionary<Node,int>() { {nodes[10], 7}}},
                {nodes[4], new Dictionary<Node,int>() { {nodes[1], 20}, {nodes[5], 5}, {nodes[6], 17}, {nodes[11], 11}}},
                {nodes[5], new Dictionary<Node,int>() { {nodes[4], 5}, {nodes[6], 6}, {nodes[8], 3}, {nodes[11], 33}}},
                {nodes[6], new Dictionary<Node,int>() { {nodes[0], 10}, {nodes[4], 17}, {nodes[5], 6}}},
                {nodes[7], new Dictionary<Node,int>() { {nodes[1], 26}, {nodes[2], 15}, {nodes[9], 3}, {nodes[11], 20}}},
                {nodes[8], new Dictionary<Node,int>() { {nodes[0], 12}, {nodes[2], 14}, {nodes[5], 3}}},
                {nodes[9], new Dictionary<Node,int>() { {nodes[1], 5}, {nodes[7], 3}}},
                {nodes[10], new Dictionary<Node,int>() { {nodes[3], 7}}},
                {nodes[11],new Dictionary<Node,int>(){ {nodes[1], 6}, {nodes[2], 9}, {nodes[4], 11}, {nodes[5], 33}, {nodes[7], 20}}}
            };
        }

        [TestMethod]
        public void PriorityQueueFindPathBetween0And9()
        {
            var path = DijkstraWithPriorityQueue.DijkstraAlgorithm(Graph, nodes[0], nodes[9]);
            var length = nodes[9].DistanceFromStart;


            var expectedPath = new[] { 0, 8, 5, 4, 11, 1, 9 };
            var expectedLength = 42;

            Assert.AreEqual(expectedLength, length);
            CollectionAssert.AreEqual(path, expectedPath);
        }

        [TestMethod]
        public void PriorityQueueFindPathBetween0And2()
        {
            var path = DijkstraWithPriorityQueue.DijkstraAlgorithm(Graph, nodes[0], nodes[2]);
            var length = nodes[2].DistanceFromStart;

            var expectedPath = new[] { 0, 8, 2 };
            var expectedLength = 26;

            Assert.AreEqual(expectedLength, length);
            CollectionAssert.AreEqual(path, expectedPath);
        }

        [TestMethod]
        public void PriorityQueueFindPathBetween0And10()
        {
            var path = DijkstraWithPriorityQueue.DijkstraAlgorithm(Graph, nodes[0], nodes[10]);

            Assert.IsNull(path);
        }

        [TestMethod]
        public void PriorityQueueFindPathBetween0And11()
        {
            var path = DijkstraWithPriorityQueue.DijkstraAlgorithm(Graph, nodes[0], nodes[11]);
            var length = nodes[11].DistanceFromStart;

            var expectedPath = new[] { 0, 8, 5, 4, 11 };
            var expectedLength = 31;

            Assert.AreEqual(expectedLength, length);
            CollectionAssert.AreEqual(path, expectedPath);
        }

        [TestMethod]
        public void PriorityQueueFindPathBetween0And1()
        {
            var path = DijkstraWithPriorityQueue.DijkstraAlgorithm(Graph, nodes[0], nodes[1]);
            var length = nodes[1].DistanceFromStart;

            var expectedPath = new[] { 0, 8, 5, 4, 11, 1 };
            var expectedLength = 37;

            Assert.AreEqual(expectedLength, length);
            CollectionAssert.AreEqual(path, expectedPath);
        }
    }
}
