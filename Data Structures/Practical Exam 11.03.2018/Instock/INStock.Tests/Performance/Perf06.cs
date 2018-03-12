using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf06
{
    [TestCase]
    public void ChangeQuantity_On_100000_ShouldWorkFast()
    {
        // Arrange
        IProductStock stock = new Instock();
        const int count = 100_000;
        List<Product> products = new List<Product>(100000);

        for (int i = 0; i < count; i++)
        {
            Product p = new Product(i.ToString(), i, i);
            stock.Add(p);
            products.Add(p);
        }

        // Act & Assert
        Stopwatch sw = Stopwatch.StartNew();
        Random rand = new Random();
        for (int i = 0; i < 50000; i++)
        {
            int qty = rand.Next(50, 50000);
            int index = rand.Next(1, 99999);
            stock.ChangeQuantity(products[index].Label, qty);
            Assert.AreEqual(products[index].Quantity, qty);
        }
        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 250);
    }
}
