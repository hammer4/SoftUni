using NUnit.Framework;
using System;
using System.Diagnostics;

[TestFixture]
public class Perf01
{
    [TestCase]
    public void Add_100000_Elements_ShouldWorkFast()
    {
        //Arrange
        IProductStock stock = new Instock();
        Stopwatch sw = new Stopwatch();
        //Act
        Random rand = new Random();
        sw.Start();
        for (int i = 0; i < 50000; i++)
        {
            int value = rand.Next(0, 10000);
            stock.Add(new Product(i.ToString(),value, value));
        }
        sw.Stop();
        //Assert
        Assert.Less(sw.ElapsedMilliseconds, 450);
    }
}
