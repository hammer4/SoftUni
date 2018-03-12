using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test28
{
    [TestCase]
    public void FindAllByQuantity_Should_Return_EmptyEnumeration_After_Change_Qty()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product1 = new Product("SalamShpekov", 3.50, 50);
        Product product2 = new Product("BekonNov", 2.65, 43);
        Product product3 = new Product("MayonezaNiskomaslena", 1.30, 13);
        Product product4 = new Product("Ketchup", 1.80, 73);
        Product product5 = new Product("Jelqzo", 0.70, 20);
        Product product6 = new Product("Belina", .75, 50);
        Product product7 = new Product("Sirene", .77, 50);
        //Act
        stock.Add(product1);
        stock.Add(product2);
        stock.Add(product3);
        stock.Add(product4);
        stock.Add(product5);
        stock.Add(product6);
        stock.Add(product7);
        stock.ChangeQuantity("Sirene", 5);
        stock.ChangeQuantity("SalamShpekov", 5);
        stock.ChangeQuantity("Belina", 5);
        //Assert
        List<Product> expected = new List<Product>();
        List<Product> actual = stock.FindAllByQuantity(50).ToList();
        CollectionAssert.AreEqual(expected, actual);
    }
}

