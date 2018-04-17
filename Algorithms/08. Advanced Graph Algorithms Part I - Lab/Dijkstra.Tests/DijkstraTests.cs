namespace Dijkstra.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DijkstraTests
    {
        private static readonly int[,] Graph =
            {
                // 0   1   2   3   4   5   6   7   8   9  10  11
                { 0,  0,  0,  0,  0,  0, 10,  0, 12,  0,  0,  0 }, // 0
                { 0,  0,  0,  0, 20,  0,  0, 26,  0,  5,  0,  6 }, // 1
                { 0,  0,  0,  0,  0,  0,  0, 15, 14,  0,  0,  9 }, // 2
                { 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  7,  0 }, // 3
                { 0, 20,  0,  0,  0,  5, 17,  0,  0,  0,  0, 11 }, // 4
                { 0,  0,  0,  0,  5,  0,  6,  0,  3,  0,  0, 33 }, // 5
                {10,  0,  0,  0, 17,  6,  0,  0,  0,  0,  0,  0 }, // 6
                { 0, 26, 15,  0,  0,  0,  0,  0,  0,  3,  0, 20 }, // 7
                {12,  0, 14,  0,  0,  3,  0,  0,  0,  0,  0,  0 }, // 8
                { 0,  5,  0,  0,  0,  0,  0,  3,  0,  0,  0,  0 }, // 9
                { 0,  0,  0,  7,  0,  0,  0,  0,  0,  0,  0,  0 }, // 10
                { 0,  6,  9,  0, 11, 33,  0, 20,  0,  0,  0,  0 }, // 11
            };
        
        [TestMethod]
        public void FindPathBetween0And9()
        {
            var path = DijkstraWithoutQueue.DijkstraAlgorithm(Graph, 0, 9);
            var length = 0;

            for (int i = 1; i < path.Count; i++)
            {
                length += Graph[path[i - 1], path[i]];
            }

            var expectedPath = new[] { 0, 8, 5, 4, 11, 1, 9 };
            var expectedLength = 42;

            Assert.AreEqual(expectedLength, length);
            CollectionAssert.AreEqual(path, expectedPath);
        }

        [TestMethod]
        public void FindPathBetween0And2()
        {
            var path = DijkstraWithoutQueue.DijkstraAlgorithm(Graph, 0, 2);
            var length = 0;

            for (int i = 1; i < path.Count; i++)
            {
                length += Graph[path[i - 1], path[i]];
            }

            var expectedPath = new[] { 0, 8, 2 };
            var expectedLength = 26;

            Assert.AreEqual(expectedLength, length);
            CollectionAssert.AreEqual(path, expectedPath);
        }

        [TestMethod]
        public void FindPathBetween0And10()
        {
            var path = DijkstraWithoutQueue.DijkstraAlgorithm(Graph, 0, 10);

            Assert.IsNull(path);
        }

        [TestMethod]
        public void FindPathBetween0And11()
        {
            var path = DijkstraWithoutQueue.DijkstraAlgorithm(Graph, 0, 11);
            var length = 0;

            for (int i = 1; i < path.Count; i++)
            {
                length += Graph[path[i - 1], path[i]];
            }

            var expectedPath = new[] { 0, 8, 5, 4, 11 };
            var expectedLength = 31;

            Assert.AreEqual(expectedLength, length);
            CollectionAssert.AreEqual(path, expectedPath);
        }

        [TestMethod]
        public void FindPathBetween0And1()
        {
            var path = DijkstraWithoutQueue.DijkstraAlgorithm(Graph, 0, 1);
            var length = 0;

            for (int i = 1; i < path.Count; i++)
            {
                length += Graph[path[i - 1], path[i]];
            }

            var expectedPath = new[] { 0, 8, 5, 4, 11, 1 };
            var expectedLength = 37;

            Assert.AreEqual(expectedLength, length);
            CollectionAssert.AreEqual(path, expectedPath);
        }
    }
}
