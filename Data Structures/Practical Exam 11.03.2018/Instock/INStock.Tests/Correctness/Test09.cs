using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test09
{
    //ChangeQuantity
    [TestCase]
    public void ChangeQuantity_On_ExistingProduct_ShouldWorkCorrectly()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product1 = new Product("SalamShpekov", 3.50, 50);
        Product product2 = new Product("BekonNov", 2.65, 43);
        Product product3 = new Product("MayonezaNiskomaslena", 1.30, 13);

        //Act
        stock.Add(product1);
        stock.Add(product2);
        stock.Add(product3);

        stock.ChangeQuantity("SalamShpekov", 3);
        int expected = 3;
        int actual = stock.FindByLabel("SalamShpekov").Quantity;
        //Assert
        Assert.AreEqual(3, stock.Count);
        Assert.AreEqual(expected, actual);
    }
}