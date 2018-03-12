using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test20
{

    [TestCase]
    public void FindAllByPriceRange_LowerEndExclusive_HigherEndInclusive_ShouldWorkCorrectly()
    {
        //Arrange
        IProductStock stock = new Instock();
        Product product1 = new Product("SalamShpekov", 3.50, 50);
        Product product2 = new Product("Kurban", 2.0, 2);
        //Act
        stock.Add(product1);
        stock.Add(product2);
        //Assert
        List<Product> expected = new List<Product>() { product1 };
        List<Product> actual = stock.FindAllInRange(2.0, 3.50).ToList();
        CollectionAssert.AreEqual(expected, actual);
    }
}

