
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test01
{
    //Addition
    [TestCase]
    public void Add_SingleElement_ShouldWorkCorrectly()
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
    }



}

