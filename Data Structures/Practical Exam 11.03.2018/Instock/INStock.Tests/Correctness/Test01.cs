using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

[TestFixture]
public class Test01
{
    //Addition
    [TestCase]
    public void Add_Single_Product_ShouldAddProduct()
    {

        //Arrange
        IProductStock stock = new Instock();
        Product product = new Product("Salam", 2.50, 50);

        //Act
        stock.Add(product);

        //Assert
        foreach (var item in stock)
        {
            if (item == product
                && (product.Price == item.Price
                && product.Label == item.Label
                && product.Quantity == item.Quantity))
            {
                Assert.Pass();
            }
        }

    }
    

    
}

