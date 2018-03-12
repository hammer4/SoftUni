using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test10
{
    //GetById
    [TestCase]
    public void GetById_On_ExistingElement_ShouldWorkCorrectly()
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
        //Assert
        Assert.AreSame(tx1, cb.GetById(5));
        Assert.AreNotSame(
            new Transaction(53, TransactionStatus.Failed, "a", "b", 5),
            cb.GetById(7)
        );
    }
}