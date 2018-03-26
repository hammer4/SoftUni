namespace SetCover.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SetCoverTests
    {
        [TestMethod]
        public void TestWithProvidedExample()
        {
            var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            var sets = new[]
            {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

            var selectedSets = SetCover.ChooseSets(sets.ToList(), universe.ToList());

            var expectedResult = new[]
            {
                sets[2],
                sets[1],
                sets[3],
                sets[4]
            };

            CollectionAssert.AreEqual(expectedResult, selectedSets);
        }

        [TestMethod]
        public void TestWithNoRedundantElements()
        {
            var universe = new[] { 1, 2, 3, 4, 5 };
            var sets = new[]
            {
                new[] { 1 },
                new[] { 2, 4 },
                new[] { 5 },
                new[] { 3 }
            };

            var selectedSets = SetCover.ChooseSets(sets.ToList(), universe.ToList());

            var expectedResult = new[]
            {
                sets[1],
                sets[0],
                sets[2],
                sets[3]
            };

            CollectionAssert.AreEqual(expectedResult, selectedSets);
        }

        [TestMethod]
        public void TestWithOneSetContainingUniverse()
        {
            var universe = new[] { 1, 2, 3, 4, 5 };
            var sets = new[]
            {
                new[] { 1, 2, 3, 4, 5 },
                new[] { 2, 3, 4, 5 },
                new[] { 5 },
                new[] { 3 }
            };

            var selectedSets = SetCover.ChooseSets(sets.ToList(), universe.ToList());

            var expectedResult = new[]
            {
                sets[0]
            };

            CollectionAssert.AreEqual(expectedResult, selectedSets);
        }

        [TestMethod]
        public void TestWithTwoSetsContainingUniverse()
        {
            var universe = new[] { 1, 2, 3, 4, 5 };
            var sets = new[]
            {
                new[] { 1, 3, 5 },
                new[] { 5, 1 },
                new[] { 3, 2 },
                new[] { 2, 4 }
            };

            var selectedSets = SetCover.ChooseSets(sets.ToList(), universe.ToList());

            var expectedResult = new[]
            {
                sets[0],
                sets[3]
            };

            CollectionAssert.AreEqual(expectedResult, selectedSets);
        }

        [TestMethod]
        public void TestWithAllSetsNeeded()
        {
            var universe = new[] { 1, 2, 3, 4, 5 };
            var sets = new[]
            {
                new[] { 1, 3, 5 },
                new[] { 1, 2 },
                new[] { 3, 4 }
            };

            var selectedSets = SetCover.ChooseSets(sets.ToList(), universe.ToList());

            var expectedResult = new[]
            {
                sets[0],
                sets[1],
                sets[2]
            };

            CollectionAssert.AreEqual(expectedResult, selectedSets);
        }

        [TestMethod]
        public void TestWithSeveralRedundantSets()
        {
            var universe = new[] { 1, 2, 3, 4, 5, 6 };
            var sets = new[]
            {
                new[] { 1, 2, 5 },
                new[] { 2, 3, 5 },
                new[] { 3, 4, 5 },
                new[] { 4, 5 },
                new[] { 1, 3, 4, 6 }
            };

            var selectedSets = SetCover.ChooseSets(sets.ToList(), universe.ToList());

            var expectedResult = new[]
            {
                sets[4],
                sets[0]
            };

            CollectionAssert.AreEqual(expectedResult, selectedSets);
        }
    }
}
