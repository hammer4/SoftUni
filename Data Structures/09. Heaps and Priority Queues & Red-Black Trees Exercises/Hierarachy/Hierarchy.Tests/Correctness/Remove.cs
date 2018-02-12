namespace Hierarchy.Tests.Correctness
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Remove : BaseTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_WithNonExistantElement_ShouldThrowException()
        {
            var nonExistingElement = 7;
            this.Hierarchy.Remove(nonExistingElement);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_WithRootElement_ShouldThrowException()
        {
            this.Hierarchy.Remove(DefaultRootValue);
        }

        [TestMethod]
        public void Remove_WithOneElement_ShouldDecreaseCountByOne()
        {
            this.Hierarchy.Add(DefaultRootValue,2);

            this.Hierarchy.Remove(2);

            Assert.AreEqual(1,this.Hierarchy.Count,"Count did not decrease correctly!");
        }

        [TestMethod]
        public void Remove_WithElementWithChildren_ShouldDecreaseCountCorrectly()
        {
            this.Hierarchy.Add(DefaultRootValue, 10);
            this.Hierarchy.Add(DefaultRootValue, 11);
            this.Hierarchy.Add(10, 12);
            this.Hierarchy.Add(10, 13);
            this.Hierarchy.Add(11, 14);
            Assert.AreEqual(6,this.Hierarchy.Count);

            this.Hierarchy.Remove(10);

            Assert.AreEqual(5, this.Hierarchy.Count, "Count did not decrease correctly!");
        }

        [TestMethod]
        public void Remove_WithElementWithNoChildren_ShouldRemoveElementCorrectly()
        {
            this.Hierarchy.Add(DefaultRootValue, 2);
            this.Hierarchy.Add(2, 3);

            this.Hierarchy.Remove(3);

            Assert.IsFalse(this.Hierarchy.Contains(3));
            Assert.IsFalse(this.Hierarchy.GetChildren(2).Contains(3));

        }

        [TestMethod]
        public void Remove_WithElementWithChildren_ShouldAttachChildrenToRemovedElementsParent()
        {
            this.Hierarchy.Add(DefaultRootValue, 10);
            this.Hierarchy.Add(DefaultRootValue, 11);
            this.Hierarchy.Add(10, 12);
            this.Hierarchy.Add(10, 13);
            this.Hierarchy.Add(11, 14);

            this.Hierarchy.Remove(10);

            Assert.AreEqual(DefaultRootValue, this.Hierarchy.GetParent(12));
            Assert.AreEqual(DefaultRootValue, this.Hierarchy.GetParent(13));

            var rootChildren = this.Hierarchy.GetChildren(DefaultRootValue).ToArray();
            CollectionAssert.AreEqual(
                rootChildren,
                new[] { 11, 12, 13 });
        }
    }
}
