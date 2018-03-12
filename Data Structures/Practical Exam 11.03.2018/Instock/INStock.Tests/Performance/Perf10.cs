using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[TestFixture]
public class Perf10
{
    [TestCase]
    public void FindFirstByAlphabeticOrder_On100000Elements_ShouldWorkFast()
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
        people.Sort();
        Stopwatch sw = Stopwatch.StartNew();
        // Act
        IEnumerable<Product> result = stock.FindFirstByAlphabeticalOrder(50000);

        // Assert
        CollectionAssert.AreEqual(people.Take(50000), result);
        sw.Stop();

        Assert.Less(sw.ElapsedMilliseconds, 100);
    }
}

