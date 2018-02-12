namespace Hierarchy.Tests.Performance
{
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetParentPerformance
    {
        [TestMethod]
        public void PerformanceGetParent_With50000ElementsWith1ParentInReversedOrder()
        {
            var hierarchy = new Hierarchy<int>(0);

            for (int i = 1; i < 50001; i++)
            {
                hierarchy.Add(0, i);
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 50000; i > 0; i--)
            {
                Assert.AreEqual(0, hierarchy.GetParent(i), "Expected parent did not match!");
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);
        }

        [TestMethod]
        public void PerformanceGetParent_With50000ElementsWith5000Parents()
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

            counter = 5001;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 1; i <= 5000; i++)
            {
                Assert.AreEqual(-88, hierarchy.GetParent(i), "Expected parent did not match!");
                for (int j = 0; j < 10; j++)
                {
                    Assert.AreEqual(i, hierarchy.GetParent(counter++), "Expected parent did not match!");
                }
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);
        }
    }
}
