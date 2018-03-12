using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class Perf01
{

    //Add (Show Visa that you are not to be reckoned with
    [TestCase]
    public void Add_100000_Transactions_Should_WorkFast()
    {

        IChainblock cb = new Chainblock();
        Stopwatch sw = new Stopwatch();
        int count = 100_000;
        TransactionStatus[] statuses = new TransactionStatus[]
        {
            TransactionStatus.Aborted,
            TransactionStatus.Failed,
            TransactionStatus.Successfull,
            TransactionStatus.Unauthorized
        };
        Random rand = new Random();
        sw.Start();
        for(int i = 0; i < count; i++)
        {
            //int status = rand.Next(0, 4);
            cb.Add(new Transaction(i, TransactionStatus.Successfull,
                i.ToString(), i.ToString(), i));
        }

        sw.Stop();
        Assert.AreEqual(count, cb.Count);
        Assert.IsTrue(sw.ElapsedMilliseconds < 400);
    }
    

}

