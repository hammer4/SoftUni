using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test17
{

    [TestCase]
    public void FindFirstByAlphabetical_On_WrongArgumentShouldThrow()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product5 = new Product("Jelqzo", 0.70, 20);
        Product product6 = new Product("Belina", .75, 50);
        Product product7 = new Product("Sirene", .77, 50);
        //Act
        stock.Add(product5);
        stock.Add(product6);
        stock.Add(product7);
        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            stock.FindFirstByAlphabeticalOrder(5).FirstOrDefault();
        });
    }
}

