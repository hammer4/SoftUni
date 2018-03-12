using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[TestFixture]
public class Perf08
{
    [TestCase]
    public void ProductByInsertOrder_ShouldWorkFast()
    {
        // Arrange
        IProductStock stock = new Instock();
        const int count = 100_000;
        List<Product> people = new List<Product>();

        for (int i = 0; i < count; i++)
        {
            people.Add(new Product(i.ToString(), i, i));
            stock.Add(people[i]);
        }

        Stopwatch sw = Stopwatch.StartNew();
        // Act & Assert
        CollectionAssert.AreEqual(people, stock.ToList());
        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 150);
    }
}
