using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test07
{

    //FindProductByIndex (InsertionOrder)
    [TestCase]
    public void Find_Product_WrongIndex_ShouldThrow()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product = new Product("Salam", 2.50, 50);
        //Act
        stock.Add(product);
        //Assert
        Assert.Throws<IndexOutOfRangeException>(() =>
            stock.Find(-5)
            , "Accessing index -5 should not be possible");
        Assert.Throws<IndexOutOfRangeException>(() =>
            stock.Find(1)
            , "Accessing index 1 when 1 element present should not be possile");
    }
}