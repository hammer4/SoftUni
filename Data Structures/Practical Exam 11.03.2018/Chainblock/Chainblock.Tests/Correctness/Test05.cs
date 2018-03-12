
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test05
{
    //Contains
    [TestCase]
    public void Contains_OnEmptyChainblock_ShouldReturnFalse()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        //Assert
        Assert.IsFalse(cb.Contains(5));
        Assert.IsFalse(cb.Contains(new Transaction(3, TransactionStatus.Failed, "a", "b", 0.5)));
    }
}