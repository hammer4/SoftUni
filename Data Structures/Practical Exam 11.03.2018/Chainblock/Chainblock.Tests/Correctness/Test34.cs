using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test34
{

    [TestCase]
    public void GetByReceiver_On_NonExisting_Receiver_ShouldThrow()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx1 = new Transaction(2, TransactionStatus.Successfull, "joro", "pesho", 1);
        Transaction tx2 = new Transaction(1, TransactionStatus.Successfull, "joro", "mesho", 1);
        Transaction tx3 = new Transaction(4, TransactionStatus.Successfull, "joro", "kalin", 15.6);
        Transaction tx4 = new Transaction(3, TransactionStatus.Successfull, "joro", "pesho", 15.6);
        Transaction tx5 = new Transaction(8, TransactionStatus.Failed, "joro", "barko", 17.8);

        //Act
        cb.Add(tx1);
        cb.Add(tx3);
        cb.Add(tx2);
        cb.Add(tx4);
        cb.Add(tx5);
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            cb.GetByReceiverOrderedByAmountThenById("mecho");
        });
    }
}

