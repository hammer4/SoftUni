using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test03
{
    [TestCase]
    public void Add_MultipleElements_CB_ShouldContainThem()
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
        Assert.IsTrue(cb.Contains(tx1));
        Assert.IsTrue(cb.Contains(tx2));
        Assert.IsTrue(cb.Contains(tx3));
    }
}