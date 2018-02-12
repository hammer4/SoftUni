using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hierarchy.Tests.Correctness
{
    [TestClass]
    public class Contains : BaseTest
    {
        [TestMethod]
        public void Contains_WithANonExistantElement_ShouldReturnFalse()
        {
            var result = this.Hierarchy.Contains(1);

            Assert.AreEqual(false, result, "Contains command returned a wrong result!");
        }

        [TestMethod]
        public void Contains_WithASingleElement_ShouldReturnTrue()
        {
            var result = this.Hierarchy.Contains(DefaultRootValue);

            Assert.AreEqual(true, result, "Contains command returned a wrong result!");
        }

        [TestMethod]
        public void Contains_WithMultipleSearchesForASingleElement_ShouldReturnConsistentResult()
        {
            this.Hierarchy.Add(DefaultRootValue, 666);

            Assert.AreEqual(true, this.Hierarchy.Contains(666), "Contains command returned wrong result!");
            Assert.AreEqual(true, this.Hierarchy.Contains(666), "Contains command returned wrong result!");
            Assert.AreEqual(true, this.Hierarchy.Contains(666), "Contains command returned wrong result!");
            Assert.AreEqual(true, this.Hierarchy.Contains(666), "Contains command returned wrong result!");
        }

        [TestMethod]
        public void Contains_WithBothExistingAndNonexsitantElements_ShouldReturnCorrectResults()
        {
            this.Hierarchy.Add(DefaultRootValue, 666);
            this.Hierarchy.Add(666, 6666);
            this.Hierarchy.Add(6666, 66666);

            Assert.IsTrue(this.Hierarchy.Contains(666), "Contains command returned wrong result!");
            Assert.IsFalse(this.Hierarchy.Contains(667), "Contains command returned wrong result!");
            Assert.IsTrue(this.Hierarchy.Contains(6666), "Contains command returned wrong result!");
            Assert.IsFalse(this.Hierarchy.Contains(6665), "Contains command returned wrong result!");
            Assert.IsFalse(this.Hierarchy.Contains(-17000), "Contains command returned wrong result!");
            Assert.IsTrue(this.Hierarchy.Contains(66666), "Contains command returned wrong result!");
        }

        [TestMethod]
        public void Contains_WithAnExistingElementWithMultipleElements_ShouldReturnTrue()
        {
            this.Hierarchy.Add(DefaultRootValue, 2);
            this.Hierarchy.Add(DefaultRootValue, 3);
            this.Hierarchy.Add(2, 4);
            this.Hierarchy.Add(3, 6);
            this.Hierarchy.Add(4, 7);

            var result = this.Hierarchy.Contains(6);

            Assert.AreEqual(true, result, "Contains command returned a wrong result!");
        }
    }
}
