namespace Hierarchy.Tests.Performance
{
    using System.Collections.Generic;
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ForEachPerformance
    {
        [TestMethod]
        public void PerformanceForEach_With55500Elements()
        {
            var start1 = 0;
            var start2 = 5000;
            var start3 = 100000;
            var elements = new List<int>();
            elements.Add(start1);
            var hierarchy = new Hierarchy<int>(start1);

            for (int i = 1; i <= 500; i++)
            {
                elements.Add(i);
                hierarchy.Add(start1, i);
                for (int j = 0; j < 10; j++)
                {
                    elements.Add(start2);
                    hierarchy.Add(i, start2);
                    for (int k = 0; k < 10; k++)
                    {
                        elements.Add(start3);
                        hierarchy.Add(start2, start3++);
                    }
                    start2++;
                }
            }

            elements.Sort();
            var counter = 0;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            foreach (var element in hierarchy)
            {
                Assert.AreEqual(elements[counter++], element, "Expected element did not match!");
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);

            Assert.AreEqual(counter, hierarchy.Count, "Incorect number of elements returned!");
        }

        [TestMethod]
        public void PerformanceForEach_With55500ElementsInterconnected()
        {
            var start1 = 0;
            var elements = new List<int>();
            elements.Add(start1);
            var hierarchy = new Hierarchy<int>(start1);

            for (int i = 1; i <= 51100; i = i + 511)
            {
                hierarchy.Add(start1, i);
                for (int j = i + 1; j <= i + 510; j = j + 51)
                {
                    hierarchy.Add(i, j);
                    for (int k = j + 1; k <= j + 50; k++)
                    {
                        hierarchy.Add(j, k);
                    }
                }
            }

            for (int i = 1; i <= 51100; i = i + 511)
            {
                elements.Add(i);
            }

            for (int i = 1; i <= 51100; i = i + 511)
            {
                for (int j = i + 1; j <= i + 510; j = j + 51)
                {
                    elements.Add(j);
                }
            }

            for (int i = 1; i <= 51100; i = i + 511)
            {
                for (int j = i + 1; j <= i + 510; j = j + 51)
                {
                    for (int k = j + 1; k <= j + 50; k++)
                    {
                        elements.Add(k);
                    }
                }
            }

            var counter = 0;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            foreach (var element in hierarchy)
            {
                Assert.AreEqual(elements[counter++], element, "Expected element did not match!");
            }

            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 200);

            Assert.AreEqual(counter, hierarchy.Count, "Incorect number of elements returned!");
        }
    }
}
