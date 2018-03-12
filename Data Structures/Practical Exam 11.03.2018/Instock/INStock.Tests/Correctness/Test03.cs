using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test03
{
    [TestCase]
    public void Add_MultipleElements_ShouldWorkCorrectly()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product1 = new Product("Salam", 2.50, 50);
        Product product2 = new Product("Bekon", 2.65, 43);
        Product product3 = new Product("Mayoneza", 1.30, 13);

        //Act
        stock.Add(product1);
        stock.Add(product2);
        stock.Add(product3);

        //Assert
        Assert.AreEqual(product1, stock.Find(0));
        Assert.AreEqual(product2, stock.Find(1));
        Assert.AreEqual(product3, stock.Find(2));
    }
}