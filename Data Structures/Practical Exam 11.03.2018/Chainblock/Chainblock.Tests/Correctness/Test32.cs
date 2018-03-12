using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test32
{

    [TestCase]
    public void GetByReceiverAndAmountRange_ShouldThrow_On_EmptyCB()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() => {
            cb.GetByReceiverAndAmountRange("pesho", 0, 20).ToList();
        });
    }
}

