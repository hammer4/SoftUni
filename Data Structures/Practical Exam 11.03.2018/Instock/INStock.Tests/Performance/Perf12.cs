using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[TestFixture]
public class Perf12
{
    [TestCase]
    public void FindAllByQuantity_On_100000_Elements_ShouldWorkFast()
    {
        // Arrange
        IProductStock stock = new Instock();
        const int count = 100_000;
        Dictionary<int, List<Product>> products
            = new Dictionary<int, List<Product>>();

        for (int i = 0; i < count; i += 400)
        {
            for (int j = 0; j < 400; j++)
            {
                Product p = new Product((i + j).ToString(), j, j);
                if (!products.ContainsKey(j)) products[j] = new List<Product>();
                stock.Add(p);
                products[j].Add(p);
            }
        }
        Stopwatch sw = Stopwatch.StartNew();
        // Act
        IEnumerable<Product> Result(int qty) => stock.FindAllByQuantity(qty);

        // Assert
        for (int i = 0; i < 100; i++)
        {
            CollectionAssert.AreEqual(products[i], Result(i));
        }
        sw.Stop();

        Assert.Less(sw.ElapsedMilliseconds, 100);
    }
}

