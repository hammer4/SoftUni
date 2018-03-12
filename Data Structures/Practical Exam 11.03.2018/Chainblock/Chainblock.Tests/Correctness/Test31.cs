using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test31
{

    [TestCase]
    public void GetByReceiverAndAmountRange_ShouldThrow_AfterRemovingReceiver()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx1 = new Transaction(5, TransactionStatus.Successfull, "joro", "pesho", 1);
        Transaction tx2 = new Transaction(6, TransactionStatus.Successfull, "joro", "mesho", 5.5);
        Transaction tx3 = new Transaction(7, TransactionStatus.Successfull, "joro", "vesho", 5.5);
        //Act
        cb.Add(tx1);
        cb.Add(tx3);
        cb.Add(tx2);
        cb.RemoveTransactionById(5);
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            cb.GetByReceiverAndAmountRange("pesho", 0, 20).ToList();
        });

    }
}

