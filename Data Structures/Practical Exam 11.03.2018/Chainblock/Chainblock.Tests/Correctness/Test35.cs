using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test35
{
    [TestCase]
    public void GetByReceiver_ShouldThrow_On_EmptyCB()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() => {
            cb.GetByReceiverOrderedByAmountThenById("pesho");
        });
    }
}

