using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test15
{

    [TestCase]
    public void ChangeTransactionStatus_On_NonExistingTranasction_ShouldThrow()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        //Assert
        Assert.Throws<ArgumentException>(
            () => cb.ChangeTransactionStatus(6, TransactionStatus.Failed)
        );
    }
}

