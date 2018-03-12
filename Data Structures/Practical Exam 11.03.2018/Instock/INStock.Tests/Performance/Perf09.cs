using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf09
{

    [TestCase]
    public void FindAllByPrice_On100000ElementsWithRandomPrice_ShouldWorkFast()
    {
        // Arrange
        IProductStock stock = new Instock();
        const int count = 100_000;
        List<Product> expected = new List<Product>();

        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            int price = random.Next(5, 30);
            Product p = new Product(i.ToString(), price, 25);
            if (price == 21)
            {
                expected.Add(p);
            }
            stock.Add(p);
        }

        Stopwatch sw = Stopwatch.StartNew();
        // Act
        IEnumerable<Product> FindAllByPrice() => stock.FindAllByPrice(21);

        // Assert
        CollectionAssert.AreEqual(expected, FindAllByPrice());
        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 25);
    }

}
