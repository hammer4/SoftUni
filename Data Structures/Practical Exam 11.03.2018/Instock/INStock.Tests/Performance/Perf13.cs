using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[TestFixture]
public class Perf13
{
    [TestCase]
    public void FindAllInPriceRange_OnLargeRange_ShouldWorkFast()
    {
        // Arrange
        IProductStock org = new Instock();
        const int count = 100_000;
        int expected = 0;

        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            int price = random.Next(10, 50000);
            if (price > 105 && price <= 10000) expected++;

            org.Add(new Product(i.ToString(), price, i));
        }

        Stopwatch sw = Stopwatch.StartNew();
        // Act
        IEnumerable<Product> FindInPriceRange() => org.FindAllInRange(105, 10000);

        // Assert
        Assert.AreEqual(expected, FindInPriceRange().Count());

        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 300);
    }
}

