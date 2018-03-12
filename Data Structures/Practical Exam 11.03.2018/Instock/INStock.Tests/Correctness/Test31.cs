using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test31
{
    [TestCase]
    public void Enumerator_ShouldReturn_EmptyEnumeration_On_Empty_Stock()
    {
        //Arrange
        IProductStock stock = new Instock();
        //Act
        //Assert
        List<Product> expected = new List<Product>();
        List<Product> actual = stock.Take(stock.Count).ToList();
        CollectionAssert.AreEqual(expected, actual);
    }
}

