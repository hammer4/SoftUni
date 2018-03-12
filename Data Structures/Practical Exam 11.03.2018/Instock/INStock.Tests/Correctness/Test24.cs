using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test24
{
    //FindFirstMostExpensiveItems
    [TestCase]
    public void FindFirstMostExpensiveProducts_Should_Return_CorrectEnumeration()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product2 = new Product("BekonNov", 2.65, 43);
        Product product3 = new Product("MayonezaNiskomaslena", 1.30, 13);
        Product product1 = new Product("SalamShpekov", 3.50, 50);
        //Act
        stock.Add(product1);
        stock.Add(product2);
        stock.Add(product3);
        //Assert
        List<Product> expected = new List<Product>() { product1, product2 };
        CollectionAssert.AreEqual(expected, stock.FindFirstMostExpensiveProducts(2));
        expected = new List<Product>() { product1 };
        CollectionAssert.AreEqual(expected, stock.FindFirstMostExpensiveProducts(1));
    }
}

