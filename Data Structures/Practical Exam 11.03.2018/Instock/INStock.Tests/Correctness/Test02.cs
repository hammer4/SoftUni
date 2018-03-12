using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test02
{
    [TestCase]
    public void Add_MultipleElements_Should_Increase_Count()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product1 = new Product("Getter", 20.5, 15);
        Product product2 = new Product("OtherPRoduct", 206.1, 67);
        Product product3 = new Product("50CentPoster", 50, 50);
        //Act
        stock.Add(product1);
        stock.Add(product2);
        stock.Add(product3);
        //Assert
        Assert.AreEqual(3, stock.Count, "Count should increase with every item.");
    }
}

