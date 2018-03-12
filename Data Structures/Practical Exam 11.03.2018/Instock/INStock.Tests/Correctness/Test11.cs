using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test11
{
    [TestCase]
    public void ChangeQuantity_On_NonExisting_Product_ShouldThrow()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product1 = new Product("SalamShpekov", 3.50, 50);
        Product product2 = new Product("BekonNov", 2.65, 43);
        Product product3 = new Product("MayonezaNiskomaslena", 1.30, 13);

        //Act

        //Assert
        Assert.Throws<ArgumentException>(() => stock.ChangeQuantity("Barekov", 0));
    }
}