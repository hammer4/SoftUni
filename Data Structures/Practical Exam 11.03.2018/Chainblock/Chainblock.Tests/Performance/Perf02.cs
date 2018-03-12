using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf02
{
    //Contains
    [TestCase]
    public void Contains_100000_ShouldWorkFast()
    {
        IChainblock cb = new Chainblock();
        int count = 100000;
        List<Transaction> txs = new List<Transaction>();
        TransactionStatus[] statuses = new TransactionStatus[]
        {
            TransactionStatus.Aborted,
            TransactionStatus.Failed,
            TransactionStatus.Successfull,
            TransactionStatus.Unauthorized
        };
        Random rand = new Random();
        for (int i = 0; i < count; i++)
        {
            int status = rand.Next(0, 4);
            Transaction tx = new Transaction(i, statuses[status],
                i.ToString(), i.ToString(), i);
            cb.Add(tx);
            txs.Add(tx);
        }

        Assert.AreEqual(count, cb.Count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Transaction tx in txs)
        {
            Assert.IsTrue(cb.Contains(tx));
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.Less(l1, 200);
    }
}


