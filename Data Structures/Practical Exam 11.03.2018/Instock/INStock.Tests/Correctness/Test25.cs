using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test25
{
    [TestCase]
    public void FindFirstMostExpensiveProducts_On_WrongArgumentPassed_ShouldThrow()
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
        //Assert
        Assert.AreEqual(3, stock.Count);
        Assert.Throws<ArgumentException>(() => {
            stock.FindFirstMostExpensiveProducts(5).First();
        });
    }
}

