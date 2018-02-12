namespace Hierarchy.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseTest
    {
        public IHierarchy<int> Hierarchy { get; private set; }

        public const int DefaultRootValue = 5;

        [TestInitialize]
        public void Initialize()
        {
            this.Hierarchy = new Hierarchy<int>(5);
        }
    }
}
