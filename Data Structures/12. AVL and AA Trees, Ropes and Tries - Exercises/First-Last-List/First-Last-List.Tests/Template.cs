using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

[TestFixture]
public class TestClass1
{
    [Test]
    public void TestMethod1()
    {

    }
}

class Product : IComparable<Product>
{
    public string Title { get; set; }
    public decimal Price { get; set; }

    public Product(decimal price, string title)
    {
        this.Price = price;
        this.Title = title;
    }

    public int CompareTo(Product other)
    {
        return this.Price.CompareTo(other.Price);

    }
}
