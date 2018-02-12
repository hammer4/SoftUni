namespace Hierarchy.Tests.Correctness
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ForEach : BaseTest
    {
        [TestMethod]
        public void ForEach_WithOnlyRoot_ShouldIterateOnlyThroughRoot()
        {
            int count = 0;
            int[] collection = new int[] { DefaultRootValue };
            foreach (var element in this.Hierarchy)
            {
                Assert.AreEqual(collection[count++], element, "Expected element did not match!");
            }
        }

        [TestMethod]
        public void ForEach_WithMultipleElements_ShouldIterateOverCollectionOnlyOnce()
        {
            int count = 0;
            this.Hierarchy.Add(DefaultRootValue, 50);
            this.Hierarchy.Add(DefaultRootValue, 70);
            this.Hierarchy.Add(70, 100);
            this.Hierarchy.Add(50, 200);
            this.Hierarchy.Add(70, 120);
            this.Hierarchy.Add(70, 110);
            this.Hierarchy.Add(110, 0);
            this.Hierarchy.Add(200, 201);
            this.Hierarchy.Add(201, 202);
            this.Hierarchy.Add(50, 300);
            int[] collection = new int[] { DefaultRootValue, 50, 70, 200, 300, 100, 120, 110, 201, 0, 202 };

            foreach (var element in this.Hierarchy)
            {
                Assert.AreEqual(collection[count++], element, "Expected element did not match!");
            }

            Assert.AreEqual(count, this.Hierarchy.Count, "Incorrect count of elements returned!");
        }

        [TestMethod]
        public void ForEach_WithMultipleElements_ShouldIterateThroughThemInCorrectOrder()
        {
            this.Hierarchy.Add(DefaultRootValue, -10);
            this.Hierarchy.Add(DefaultRootValue, 10);
            this.Hierarchy.Add(-10, -11);
            this.Hierarchy.Add(-10, -12);
            this.Hierarchy.Add(10, 11);
            this.Hierarchy.Add(10, 12);
            this.Hierarchy.Add(-11, -13);
            this.Hierarchy.Add(-11, -14);
            this.Hierarchy.Add(-12, -15);
            this.Hierarchy.Add(-12, -16);
            this.Hierarchy.Add(11, 13);
            int count = 0;
            int[] collection = new int[] { DefaultRootValue, -10, 10, -11, -12, 11, 12, -13, -14, -15, -16, 13 };
            foreach (var element in this.Hierarchy)
            {
                Assert.AreEqual(collection[count++], element, "Expected element did not match!");
            }
        }
    }
}
