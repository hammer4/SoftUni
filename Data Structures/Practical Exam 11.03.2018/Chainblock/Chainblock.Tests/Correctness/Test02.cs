
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test02
{
    [TestCase]
    public void Add_SingleElement_ShouldIncreaseCountTo1()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx = new Transaction(5, TransactionStatus.Successfull, "joro", "pesho", 5);
        //Act
        cb.Add(tx);

        //Assert
        foreach (var transaction in cb)
        {
            Assert.AreSame(transaction, tx);
        }

        Assert.AreEqual(1, cb.Count);
    }
}

