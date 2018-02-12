namespace Hierarchy.Tests.Correctness
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Constructor
    {
        [TestMethod]
        public void Constructor_NewHierarchyShouldHaveExactly1Element()
        {
            var hierarchy = new Hierarchy<int>(5);
            Assert.AreEqual(1, hierarchy.Count);
        }

        [TestMethod]
        public void Constructor_NewHierarchyShouldHaveCorrectElement()
        {
            var hierarchy = new Hierarchy<int>(5);
            Assert.IsTrue(hierarchy.Contains(5));
        }

        [TestMethod]
        public void Hierarchy_ShouldBeGeneric()
        {
            var hierarchy = new Hierarchy<string>("test");
            Assert.IsTrue(hierarchy.Contains("test"));
        }
    }
}
