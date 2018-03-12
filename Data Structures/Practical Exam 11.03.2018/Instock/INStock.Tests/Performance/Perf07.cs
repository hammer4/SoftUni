using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf07
{
    [TestCase]
    public void ChangeQuantity_100000_OnSameProduct_ShouldWorkFast()
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
            int qty = rand.Next(50, 10000);
            stock.ChangeQuantity(products[576].Label, qty);
            Assert.AreEqual(products[576].Quantity, qty);
        }
        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 200);
    }
}
