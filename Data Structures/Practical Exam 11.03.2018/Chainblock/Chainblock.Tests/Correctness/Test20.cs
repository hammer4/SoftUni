
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test20
{

    [TestCase]
    public void GetAllInAmountRange_ShouldReturnEmptyEnumeration_On_EmptyCB()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        List<Transaction> actual = cb.GetAllInAmountRange(7.7, 7.75).ToList();
        //Assert
        CollectionAssert.AreEqual(new List<Transaction>(), actual);
    }
}

