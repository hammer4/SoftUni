using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test13
{
    //ChangeTxStatus
    [TestCase]
    public void ChangeTransactionStatus_ShouldWorkCorrectly_On_ExistingTX()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx1 = new Transaction(5, TransactionStatus.Successfull, "joro", "pesho", 5);
        Transaction tx2 = new Transaction(6, TransactionStatus.Successfull, "joro", "pesho", 5);
        Transaction tx3 = new Transaction(7, TransactionStatus.Successfull, "joro", "pesho", 5);
        //Act
        cb.Add(tx1);
        cb.Add(tx2);
        cb.Add(tx3);
        cb.ChangeTransactionStatus(5, TransactionStatus.Aborted);
        //Assert
        Assert.AreEqual(TransactionStatus.Aborted, tx1.Status);
        Assert.AreEqual(3, cb.Count);
    }
}

