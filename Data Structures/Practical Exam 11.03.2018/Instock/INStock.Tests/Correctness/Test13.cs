using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test13
{
    //FindProductByLabel
    [TestCase]
    public void FindByLabel_Should_Work_Correctly()
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
        //Assert
        Assert.IsTrue(stock.Contains(product1));
        Assert.AreSame(product2, stock.FindByLabel("BekonNov")
            , "FindByLabel on existing element should return the element itself");
    }
}

