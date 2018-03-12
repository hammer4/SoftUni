using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test04
{
    //Contains
    [TestCase]
    public void Add_SingleElement_Contains_ShouldReturnTrue()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product = new Product("Pizza", 4.30, 1510);

        //Act
        stock.Add(product);

        //Assert
        var actual = stock.Contains(product);
        Assert.True(actual, "Contains on existing element return true");
    }
}

