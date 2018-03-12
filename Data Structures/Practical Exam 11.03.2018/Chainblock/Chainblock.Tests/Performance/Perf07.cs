using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf07
{
    //GetByTxStatus
    [TestCase]
    public void GetByTransactionStatus_ShouldWorkFast()
    {
        IChainblock cb = new Chainblock();
        List<Transaction> txs = new List<Transaction>();
        Random rand = new Random();
        for (int i = 0; i < 100000; i++)
        {
            int amount = rand.Next(0, 50000);
            Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                i.ToString(), i.ToString(), amount);

            cb.Add(tx);
            txs.Add(tx);
        }

        int count = cb.Count;
        Assert.AreEqual(100000, count);
        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Transaction> byStatus = cb.GetByTransactionStatus(
            TransactionStatus.Successfull);
        int c = 0;

        foreach (Transaction employee in byStatus)
        {
            c++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
        Assert.AreEqual(100000, c);
    }
}


