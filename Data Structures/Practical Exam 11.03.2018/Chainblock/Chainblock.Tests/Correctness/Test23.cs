using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test23
{
    [TestCase]
    public void GetAllOrderedByAmountDescendingThenById_ShouldReturnEmpty_OnEmptyCB()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        List<Transaction> actual = cb.GetAllOrderedByAmountDescendingThenById().ToList();
        //Assert
        CollectionAssert.AreEqual(new List<Transaction>(), actual);
    }

}

