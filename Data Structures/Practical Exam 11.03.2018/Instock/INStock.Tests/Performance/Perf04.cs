using NUnit.Framework;

[TestFixture]
public class Perf04
{
    [TestCase]
    public void Add_Many_Count_ShouldWork()
    {
        // Arrange
        IProductStock stock = new Instock();
        const int count = 100_000;

        // Act & Assert
        for (int i = 0; i < count; i++)
        {
            Assert.AreEqual(i, stock.Count);
            stock.Add(new Product(i.ToString(), i, i));
        }
    }
}
