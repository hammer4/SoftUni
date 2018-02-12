namespace Hierarchy.Tests.Performance
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetChildrenPerformance
    {
        [TestMethod]
        public void PerformanceGetChildren_With1ElementWith50000ChildrenInReversedOrder()
        {
            var hierarchy = new Hierarchy<int>(-17);

            for (int i = 50000; i > 0; i--)
            {
                hierarchy.Add(-17, i);
            }

            var children = Enumerable.Range(1, 50000).Reverse().ToArray();

            Stopwatch timer = new Stopwatch();
            timer.Start();

            CollectionAssert.AreEqual(children, hierarchy.GetChildren(-17).ToArray(), "Children collection did not match!");

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);
        }

        [TestMethod]
        public void PerformanceGetChildren_With50000ElementsWith5000Parents()
        {
            var counter = 5001;
            var hierarchy = new Hierarchy<int>(-88);
            for (int i = 1; i <= 5000; i++)
            {
                hierarchy.Add(-88, i);
                for (int j = 0; j < 10; j++)
                {
                    hierarchy.Add(i, counter++);
                }
            }

            var baseChildren = Enumerable.Range(1, 5000).ToArray();
            counter = 5001;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 1; i <= 5000; i++)
            {
                var children = hierarchy.GetChildren(i);
                var count = 0;
                foreach (var child in children)
                {
                    count++;
                    Assert.AreEqual(counter++, child, "Children collection did not match!");
                }

                Assert.AreEqual(10, count, "Incorrect children collection count!");
            }

            CollectionAssert.AreEqual(baseChildren, hierarchy.GetChildren(-88).ToArray(), "Expected children did not match!");

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 50);
        }
    }
}
