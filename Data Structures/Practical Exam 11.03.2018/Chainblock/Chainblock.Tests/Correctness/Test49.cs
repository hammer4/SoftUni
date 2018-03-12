using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestFixture]
public class Test49
{
    [TestCase]
    public void GetByRceiver_ShouldReturnCorrectRange_CorrectlyOrdered()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        Transaction tx1 = new Transaction(2, TransactionStatus.Successfull, "joro", "pesho", 1);
        Transaction tx2 = new Transaction(1, TransactionStatus.Successfull, "joro", "pesho", 1);
        Transaction tx3 = new Transaction(4, TransactionStatus.Successfull, "joro", "pesho", 15.6);
        Transaction tx4 = new Transaction(3, TransactionStatus.Successfull, "joro", "pesho", 15.6);
        Transaction tx5 = new Transaction(8, TransactionStatus.Failed, "joro", "pesho", 17.8);
        List<Transaction> expected = new List<Transaction>()
        {
            tx5, tx4, tx3, tx2, tx1
        };
        //Act
        cb.Add(tx1);
        cb.Add(tx3);
        cb.Add(tx2);
        cb.Add(tx4);
        cb.Add(tx5);
        //Assert
        List<Transaction> actual = cb.GetByReceiverAndAmountRange("pesho", 0, 20).ToList();
        CollectionAssert.AreEqual(expected, actual);
    }
}

