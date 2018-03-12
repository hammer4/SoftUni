using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test12
{
    [TestCase]
    public void ChangeQuantity_On_Multiple_Elements_ShouldWorkCorrectly()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product1 = new Product("SalamShpekov", 3.50, 560);
        Product product2 = new Product("BekonNov", 2.65, 43);
        Product product3 = new Product("MayonezaNiskomaslena", 1.30, 13);
        Product product4 = new Product("Ketchup", 1.80, 73);
        Product product5 = new Product("Jelqzo", 0.70, 130);
        Product product6 = new Product("Belina", .75, 240);
        Product product7 = new Product("Sirene", .77, 30);

        //Act
        stock.Add(product1);
        stock.Add(product2);
        stock.Add(product3);
        stock.Add(product4);
        stock.Add(product5);
        stock.Add(product6);
        stock.Add(product7);

        stock.ChangeQuantity(product4.Label, 50);
        stock.ChangeQuantity(product7.Label, 50);
        stock.ChangeQuantity(product3.Label, 50);

        //Assert
        List<Product> expected = new List<Product>() { product4, product7, product3 };
        List<Product> actual = stock.FindAllByQuantity(50).ToList();
        CollectionAssert.AreEqual(expected, actual);
    }

}

