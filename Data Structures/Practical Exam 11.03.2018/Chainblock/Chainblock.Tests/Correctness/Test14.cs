using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test14
{
    [TestCase]
    public void ChangeTransactionStatus_OnMultipleTransactions_ShouldWorkCorrectly()
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
        cb.ChangeTransactionStatus(7, TransactionStatus.Unauthorized);
        cb.ChangeTransactionStatus(5, TransactionStatus.Aborted);
        cb.ChangeTransactionStatus(6, TransactionStatus.Successfull);
        //Assert
        Assert.AreEqual(3, cb.Count);
        Assert.AreEqual(tx1.Status, TransactionStatus.Aborted);
        Assert.AreEqual(tx3.Status, TransactionStatus.Unauthorized);
        Assert.AreEqual(tx2.Status, TransactionStatus.Successfull);
    }
}

