namespace Hierarchy.Tests.Correctness
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetCommonElements : BaseTest
    {
        [TestMethod]
        public void GetCommonElements_WithHierarchyWithoutCommonElements_ShouldReturnAnEmptyCollection()
        {
            var otherHierarchy = new Hierarchy<int>(1);

            var result = this.Hierarchy.GetCommonElements(otherHierarchy).ToArray();

            CollectionAssert.AreEquivalent(result, new int[0],"GetCommonElements returned an incorrect collection!");
        }

        [TestMethod]
        public void GetCommonElements_WithHierarchyWithOneCommonElement_ShouldReturnACollectionOfCorrectElement()
        {
            var otherHierarchy = new Hierarchy<int>(1);
            otherHierarchy.Add(1,13);
            this.Hierarchy.Add(DefaultRootValue,13);

            var result = this.Hierarchy.GetCommonElements(otherHierarchy).ToArray();

            CollectionAssert.AreEquivalent(result, new [] {13}, "GetCommonElements returned an incorrect collection!");
        }

        [TestMethod]
        public void GetCommonElements_WithHierarchyWithMultipleCommonElements_ShouldReturnACorrectCollection()
        {
            var otherHierarchy = new Hierarchy<int>(10);
            otherHierarchy.Add(10, -22);
            otherHierarchy.Add(-22, 56);
            otherHierarchy.Add(10, 108);
            otherHierarchy.Add(-22, 34);
            this.Hierarchy.Add(DefaultRootValue, 100);
            this.Hierarchy.Add(DefaultRootValue, -22);
            this.Hierarchy.Add(100, 34);
            this.Hierarchy.Add(100, 10);

            var result = this.Hierarchy.GetCommonElements(otherHierarchy).ToArray();

            CollectionAssert.AreEquivalent(result, new[] { -22,34,10 }, "GetCommonElements returned an incorrect collection!");
        }
    }
}
