using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf02
{
    [TestCase]
    public void Contains_100000_Elements_ShouldExecuteFast()
    {
        // Arrange
        IProductStock stock = new Instock();
        const int count = 100000;
        LinkedList<Product> products = new LinkedList<Product>();

        for (int i = 0; i < count; i++)
        {
            products.AddLast(new Product(i.ToString(), i, i));
            stock.Add(products.Last.Value);
        }

        // Act
        Stopwatch sw = Stopwatch.StartNew();
        LinkedListNode<Product> node = products.First;
        while (node != null)
        {
            Assert.True(stock.Contains(node.Value));
            node = node.Next;
        }

        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 250);
    }
}
