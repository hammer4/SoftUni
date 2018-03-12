using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test05
{
    [TestCase]
    public void Contains_On_Non_ExistingElement_ShouldReturnFalse()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product = new Product("Pizza", 4.30, 1510);
        Product product2 = new Product("Rizza", 4.30, 1510);

        //Act
        stock.Add(product);

        //Assert
        var actual = stock.Contains(product2);
        Assert.False(actual, "Contains on non-existing element should return false");

    }
}