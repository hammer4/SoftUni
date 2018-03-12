using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test08
{
    [TestCase]
    public void Find_Product_On_ExistingProduct_ShouldWorkCorrectly()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product1 = new Product("Balsam", 5.3, 12);
        Product product2 = new Product("Korab", 12.6, 1255);
        Product product3 = new Product("Meduza", 53.1, 55);
        //Act
        stock.Add(product1);
        stock.Add(product2);
        stock.Add(product3);
        //Assert
        Assert.AreSame(product3, stock.Find(2));
        Assert.AreNotSame(product1, stock.Find(1));
        Assert.AreSame(product1, stock.Find(0));
    }
}