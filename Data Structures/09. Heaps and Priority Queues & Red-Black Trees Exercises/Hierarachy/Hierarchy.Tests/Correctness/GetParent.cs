namespace Hierarchy.Tests.Correctness
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetParent : BaseTest
    {
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetParent_WithNonExistantElement_ShouldThrowException()
        {
            this.Hierarchy.GetParent(-17);
        }

        [TestMethod]
        public void GetParent_WithRoot_ShouldReturnDefault()
        {
            var result = this.Hierarchy.GetParent(DefaultRootValue);

            Assert.AreEqual(default(int), result, "GetParent command returned a wrong result!");
        }

        [TestMethod]
        public void GetParent_WithANodeWithAParent_ShouldReturnParentValue()
        {
            this.Hierarchy.Add(DefaultRootValue,17);
            this.Hierarchy.Add(DefaultRootValue, 20);
            this.Hierarchy.Add(17, 22);
            this.Hierarchy.Add(20,15);
            this.Hierarchy.Add(20, -33);

            var result = this.Hierarchy.GetParent(-33);

            Assert.AreEqual(20, result, "GetParent command returned a wrong result!");
        }
    }
}
