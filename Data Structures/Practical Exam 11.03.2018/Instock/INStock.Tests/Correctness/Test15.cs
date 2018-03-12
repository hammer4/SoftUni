using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test15
{

    //One more mby
    //FindFirstByAlphabeticalOrder
    [TestCase]
    public void FindFirstByAlphabeticalOrder_Should_ReturnCorrectEnumeration()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product1 = new Product("Abra", 3.50, 50);
        Product product2 = new Product("Bobar", 2.65, 43);
        Product product3 = new Product("Caza", 1.30, 13);
        Product product4 = new Product("Darfield", 1.80, 73);
        Product product5 = new Product("Eil*", 0.70, 20);
        Product product6 = new Product("Flen", .75, 50);
        Product product7 = new Product("Giilqzo", .77, 50);
        //Act
        stock.Add(product1);
        stock.Add(product2);
        stock.Add(product3);
        stock.Add(product4);
        stock.Add(product5);
        stock.Add(product6);
        stock.Add(product7);
        //Assert
        List<Product> expected = new List<Product>()
        {
            product1,product2,product3,product4,product5,product6,product7
        };
        List<Product> actual = stock.FindFirstByAlphabeticalOrder(stock.Count).ToList();
        CollectionAssert.AreEqual(expected, actual);
    }
}

