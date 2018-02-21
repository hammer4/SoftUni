using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class PerformanceTestsFirstLastList
{
    private IFirstLastList<Product> products =
        FirstLastListFactory.Create<Product>();

    private int addCounter = 0;

    private void AddProducts(int count)
    {
        for (int i = 0; i < count; i++)
        {
            ++addCounter;
            this.products.Add(
                new Product(addCounter % 1000, "Product" + addCounter));
        }
    }

    [TestMethod]
    [Timeout(200)]
    public void TestPerformance_Add()
    {
        // Act
        AddProducts(25000);
        Assert.AreEqual(25000, this.products.Count);
    }

    [TestMethod]
    [Timeout(200)]
    public void TestPerformance_First()
    {
        // Arrange
        AddProducts(10000);

        // Act
        for (int i = 0; i < 500; i++)
        {
            AddProducts(1);
            var returnedProducts = this.products.First(i).ToList();
            Assert.AreEqual(i, returnedProducts.Count);
        }
    }

    [TestMethod]
    [Timeout(200)]
    public void TestPerformance_Last()
    {
        // Arrange
        AddProducts(10000);

        // Act
        for (int i = 0; i < 500; i++)
        {
            AddProducts(1);
            var returnedProducts = this.products.Last(i).ToList();
            Assert.AreEqual(i, returnedProducts.Count);
        }
    }

    [TestMethod]
    [Timeout(200)]
    public void TestPerformance_Min()
    {
        // Arrange
        AddProducts(10000);

        // Act
        for (int i = 0; i < 230; i++)
        {
            AddProducts(1);
            var returnedProducts = this.products.Min(i).ToList();
            Assert.AreEqual(i, returnedProducts.Count);
        }
    }

    [TestMethod]
    [Timeout(200)]
    public void TestPerformance_Max()
    {
        // Arrange
        AddProducts(10000);

        // Act
        for (int i = 0; i < 230; i++)
        {
            AddProducts(1);
            var returnedProducts = this.products.Max(i).ToList();
            Assert.AreEqual(i, returnedProducts.Count);
        }
    }

    [TestMethod]
    [Timeout(200)]
    public void TestPerformance_RemoveAll()
    {
        // Arrange
        AddProducts(12000);

        // Act
        while (this.products.Count > 0)
        {
            AddProducts(1);
            var first = this.products.First(1).FirstOrDefault();
            this.products.RemoveAll(first);
        }
    }
}
