using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test19
{
    [TestCase]
    public void GetAllInAmountRange_ShouldReturn_EmptyCollectionOnNonExistingRange()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx1 = new Transaction(5, TransactionStatus.Successfull, "joro", "pesho", 1);
        Transaction tx2 = new Transaction(6, TransactionStatus.Successfull, "joro", "pesho", 2);
        Transaction tx3 = new Transaction(7, TransactionStatus.Successfull, "joro", "pesho", 5.5);
        Transaction tx4 = new Transaction(12, TransactionStatus.Successfull, "joro", "pesho", 15.6);
        Transaction tx5 = new Transaction(15, TransactionStatus.Successfull, "joro", "pesho", 7.8);
        List<Transaction> expected = new List<Transaction>();
        //Act
        cb.Add(tx1);
        cb.Add(tx3);
        cb.Add(tx2);
        cb.Add(tx4);
        cb.Add(tx5);
        List<Transaction> actual = cb.GetAllInAmountRange(7.7, 7.75).ToList();
        //Assert
        CollectionAssert.AreEqual(expected, actual);
        cb.RemoveTransactionById(12);
        cb.RemoveTransactionById(15);
        actual = cb.GetAllInAmountRange(7.8, 16).ToList();
        CollectionAssert.AreEqual(expected, actual);
    }
}

