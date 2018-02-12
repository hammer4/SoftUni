namespace Hierarchy.Tests.Performance
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetCommonElements
    {
        [TestMethod]
        public void PerformanceGetCommonElements_WithNoCommonElements()
        {
            var start1 = 0;
            var start2 = 100000;
            var hierarchy = new Hierarchy<int>(start1);
            var hierarchy2 = new Hierarchy<int>(start2);

            for (int i = 1; i <= 50000; i++)
            {
                hierarchy.Add(start1, i);
                hierarchy2.Add(start2, start2 + i);
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();

            CollectionAssert.AreEqual(new int[0], hierarchy.GetCommonElements(hierarchy2).ToArray(), "GetCommonElements method returned incorrect collection!");

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);
        }

        [TestMethod]
        public void PerformanceGetCommonElements_WithHalfCommonElementsInBothCollections()
        {
            var start1 = 0;
            var start2 = 75000;
            var hierarchy = new Hierarchy<int>(start1);
            var hierarchy2 = new Hierarchy<int>(start2);

            for (int i = 1; i <= 50000; i++)
            {
                hierarchy.Add(start1, i);
            }

            for (int i = start2 - 1; i > 25000; i--)
            {
                hierarchy2.Add(start2, i);
            }

            var common = Enumerable.Range(25001, 25000).ToArray();

            Stopwatch timer = new Stopwatch();
            timer.Start();

            CollectionAssert.AreEqual(common, hierarchy.GetCommonElements(hierarchy2).ToArray(), "GetCommonElements method returned incorrect collection!");

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);
        }
    }
}
