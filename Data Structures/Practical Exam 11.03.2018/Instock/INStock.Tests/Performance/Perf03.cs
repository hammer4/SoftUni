using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf03
{
    [TestCase]
    public void FindAtIndex_On_100_000_Elements_ShouldWorkFast()
    {
        // Arrange
        IProductStock stock = new Instock();
        const int count = 100000;
        List<Product> people = new List<Product>();

        for (int i = 0; i < count; i++)
        {
            people.Add(new Product(i.ToString(), i, i));
            stock.Add(people[i]);
        }

        // Act
        Stopwatch sw = Stopwatch.StartNew();
        Random rand = new Random();
        for (int i = 0; i < 50_000; i++)
        {
            int rnd = rand.Next(0, count - 1);
            Assert.AreEqual(people[rnd], stock.Find(rnd));
        }
        // Assert
        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 200);
    }

}
