using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test29
{
    [TestCase]
    public void GetAllReceiversWithTransactionStatus_ShoudlThrowAfterRemove()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx1 = new Transaction(5, TransactionStatus.Successfull, "joro", "pesho", 1);
        Transaction tx2 = new Transaction(6, TransactionStatus.Successfull, "joro", "pesho", 5.5);
        Transaction tx3 = new Transaction(7, TransactionStatus.Successfull, "joro", "pesho", 5.5);
        Transaction tx4 = new Transaction(12, TransactionStatus.Successfull, "joro", "pesho", 15.6);
        Transaction tx5 = new Transaction(15, TransactionStatus.Failed, "joro", "pesho", 7.8);
        //Act
        cb.Add(tx1);
        cb.Add(tx3);
        cb.Add(tx2);
        cb.Add(tx4);
        cb.Add(tx5);
        cb.RemoveTransactionById(5);
        cb.RemoveTransactionById(7);
        cb.RemoveTransactionById(6);
        cb.RemoveTransactionById(12);
        cb.RemoveTransactionById(15);
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            cb.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed);
        });
    }
}

