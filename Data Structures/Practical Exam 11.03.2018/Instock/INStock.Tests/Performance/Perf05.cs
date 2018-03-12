using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf05
{
    [TestCase]
    public void FindByLabel_Shoul_WorkFast_On_100000_Products()
    {
        // Arrange
        IProductStock stock = new Instock();
        const int count = 100000;
        List<KeyValuePair<string, Product>> names = new List<KeyValuePair<string, Product>>(100000);

        for (int i = 0; i < count; i++)
        {
            Product p = new Product(i.ToString(), i, i);
            stock.Add(p);
            names.Add(new KeyValuePair<string, Product>(p.Label, p));
        }

        // Act
        Stopwatch sw = Stopwatch.StartNew();
        bool Result(int index)
        {
            return stock.FindByLabel(names[index].Key) == names[index].Value;
        }

        // Assert
        for (int i = 0; i < count; i++)
        {
            Assert.True(Result(i));
        }

        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 230);
    }
}
