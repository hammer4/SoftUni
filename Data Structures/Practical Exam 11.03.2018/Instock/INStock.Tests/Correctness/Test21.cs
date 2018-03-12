using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test21
{
    //FindAllByPrice
    [TestCase]
    public void FindByPrice_On_ExistingItems_ShouldReturn_Correct_Enumeration()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product1 = new Product("SalamShpekov", 2.65, 50);
        Product product2 = new Product("BekonNov", 2.65, 43);
        Product product3 = new Product("MayonezaNiskomaslena", 1.30, 13);
        Product product4 = new Product("Ketchup", 2.65, 73);
        Product product5 = new Product("Jelqzo", 0.70, 20);
        Product product6 = new Product("Belina", .75, 50);
        Product product7 = new Product("Sirene", .77, 50);
        List<Product> expected = new List<Product>() { product1, product2, product4 };
        //Act
        stock.Add(product1);
        stock.Add(product2);
        stock.Add(product3);
        stock.Add(product4);
        stock.Add(product5);
        stock.Add(product6);
        stock.Add(product7);

        //Assert
        List<Product> actual = stock.FindAllByPrice(2.65).ToList();
        CollectionAssert.AreEqual(expected, actual);
    }
}

