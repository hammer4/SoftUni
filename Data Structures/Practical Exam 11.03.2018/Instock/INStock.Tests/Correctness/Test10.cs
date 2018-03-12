using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test10
{
    [TestCase]
    public void Add_Single_Product_ShouldBeAt_0_Index()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product = new Product("Salam", 2.50, 50);
        //Act
        stock.Add(product);
        //Assert
        Assert.AreEqual(product, stock.Find(0), "Added item should be on index 0");
    }
}