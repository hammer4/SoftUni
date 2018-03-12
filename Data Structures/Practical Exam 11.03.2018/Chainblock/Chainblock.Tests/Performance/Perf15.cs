using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf15
{// GetAllSendersWithTransactionStatus
    [TestCase]
    public void GetAllSendersWithTransactionStatus_ShouldWorkFast()
    {
        IChainblock cb = new Chainblock();
        List<Transaction> txs = new List<Transaction>();
        TransactionStatus[] statuses = new TransactionStatus[]
        {
            TransactionStatus.Aborted,
            TransactionStatus.Failed,
            TransactionStatus.Successfull,
            TransactionStatus.Unauthorized
        };
        Random rand = new Random();
        Stopwatch sw = new Stopwatch();
        for (int i = 0; i < 100000; i++)
        {
            int status = rand.Next(0, 4);
            TransactionStatus TS = statuses[status];
            Transaction tx = new Transaction(i, TS,
                i.ToString(), i.ToString(), i);
            cb.Add(tx);
            if (TS == TransactionStatus.Successfull) txs.Add(tx);
        }
        txs.Reverse();
        int count = cb.Count;
        Assert.AreEqual(100000, count);
        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<string> all = cb.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
        int c = 0;
        foreach (string tx in all)
        {
            Assert.AreEqual(tx, txs[c].From);
            c++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.Less(l1, 150);
        Assert.AreEqual(txs.Count, c);
    }

}


