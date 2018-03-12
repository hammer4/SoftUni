using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[TestFixture]
public class Perf11
{
    [TestCase]
    public void FindFirstMostExpensiveItems_On100000Elements_ShouldWorkFast()
    {
        // Arrange
        IProductStock stock = new Instock();
        const int count = 100_000;
        LinkedList<Product> people = new LinkedList<Product>();

        for (int i = 0; i < count; i++)
        {

            people.AddFirst(new Product(i.ToString(), i, i));
            stock.Add(people.First.Value);
        }
        Stopwatch sw = Stopwatch.StartNew();
        // Act
        IEnumerable<Product> result = stock.FindFirstMostExpensiveProducts(50000);

        // Assert
        CollectionAssert.AreEqual(people.Take(50000), result);
        sw.Stop();

        Assert.Less(sw.ElapsedMilliseconds, 120);
    }
}

