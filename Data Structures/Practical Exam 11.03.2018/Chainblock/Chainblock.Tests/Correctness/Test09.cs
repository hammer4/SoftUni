
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test09
{
    [TestCase]
    public void Count_Should_RemainCorrect_AfterRemoving()
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
        cb.RemoveTransactionById(tx1.Id);
        cb.RemoveTransactionById(tx3.Id);
        //Assert
        Assert.AreEqual(1, cb.Count);
        Assert.AreNotSame(tx1, cb.GetById(tx2.Id));
    }
}