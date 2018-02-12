namespace Hierarchy.Tests.Performance
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemovePerformance
    {
        [TestMethod]
        public void PerformanceRemove_With2GroupsOf25000RemovalsWith50000Elements()
        {
            var count = 50001;
            var counter1 = 1;
            var counter2 = 25001;
            var hierarchy = new Hierarchy<int>(-1);
            hierarchy.Add(-1, 1);
            hierarchy.Add(-1, 25001);
            for (int i = 1; i < 25000; i++)
            {
                hierarchy.Add(counter1, ++counter1);
                hierarchy.Add(counter2, ++counter2);
            }


            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 1; i < 25001; i++)
            {
                hierarchy.Remove(i);
                hierarchy.Remove(25000 + i);
                count -= 2;
                Assert.AreEqual(count, hierarchy.Count, "Count did not decrease correctly!");
            }
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);

            Assert.AreEqual(1, hierarchy.Count, "Incorrect count after removal!");
            Assert.IsTrue(hierarchy.Contains(-1));
            CollectionAssert.AreEqual(new int[0], hierarchy.GetChildren(-1).ToArray(), "Children were not deleted correcly after removal!");
        }

        [TestMethod]
        public void PerformanceRemove_With20000RemovalsIn4GroupsInReverseOrderFromTheMiddleWith40000Elements()
        {
            var counter1 = 10000;
            var counter2 = 20000;
            var counter3 = 30000;
            var counter4 = 40000;
            var hierarchy = new Hierarchy<int>(-2);

            hierarchy.Add(-2, 10000);
            hierarchy.Add(-2, 20000);
            hierarchy.Add(-2, 30000);
            hierarchy.Add(-2, 40000);
            for (int i = 1; i < 10000; i++)
            {
                hierarchy.Add(counter1, --counter1);
                hierarchy.Add(counter2, --counter2);
                hierarchy.Add(counter3, --counter3);
                hierarchy.Add(counter4, --counter4);
            }

            var count = 40001;
            counter1 = 9000;
            counter2 = 18000;
            counter3 = 27000;
            counter4 = 36000;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 1; i < 5001; i++)
            {
                hierarchy.Remove(counter1--);
                hierarchy.Remove(counter2--);
                hierarchy.Remove(counter3--);
                hierarchy.Remove(counter4--);
                count -= 4;
                Assert.AreEqual(count, hierarchy.Count, "Count did not decrease correctly!");
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);

            Assert.AreEqual(20001, hierarchy.Count, "Incorrect count after removal!");
            counter1 = 9000;
            counter2 = 18000;
            counter3 = 27000;
            counter4 = 36000;
            for (int i = 0; i < 5000; i++)
            {
                Assert.IsFalse(hierarchy.Contains(counter1--));
                Assert.IsFalse(hierarchy.Contains(counter2--));
                Assert.IsFalse(hierarchy.Contains(counter3--));
                Assert.IsFalse(hierarchy.Contains(counter4--));
            }

            Assert.IsTrue(hierarchy.Contains(-2));
            CollectionAssert.AreEqual(new[] { 4000 }, hierarchy.GetChildren(9001).ToArray(), "Children were not correctly reattached!");
            CollectionAssert.AreEqual(new[] { 13000 }, hierarchy.GetChildren(18001).ToArray(), "Children were not correctly reattached!");
            CollectionAssert.AreEqual(new[] { 22000 }, hierarchy.GetChildren(27001).ToArray(), "Children were not correctly reattached!");
            CollectionAssert.AreEqual(new[] { 31000 }, hierarchy.GetChildren(36001).ToArray(), "Children were not correctly reattached!");
        }
    }
}
