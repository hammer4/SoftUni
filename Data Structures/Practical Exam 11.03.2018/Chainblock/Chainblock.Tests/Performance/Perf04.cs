using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf04
{
    //ChangeTransactionStatus
    [TestCase]
    public void ChangeTransactionStatus_ShouldWorkFast()
    {
        IChainblock cb = new Chainblock();
        TransactionStatus[] statuses = new TransactionStatus[]
        {
            TransactionStatus.Aborted,
            TransactionStatus.Failed,
            TransactionStatus.Successfull,
            TransactionStatus.Unauthorized
        };
        Random rand = new Random();
        List<Transaction> txs = new List<Transaction>();
        for (int i = 0; i < 90000; i++)
        {
            int amount = rand.Next(0, 50000);
            int status = amount % 4;
            Transaction tx = new Transaction(i, statuses[status],
                i.ToString(), i.ToString(), amount);
            cb.Add(tx);
            txs.Add(tx);
        }

        int count = cb.Count;
        Assert.AreEqual(90000, count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Transaction tx in txs)
        {
            int status = rand.Next(0, 4);
            cb.ChangeTransactionStatus(tx.Id, statuses[status]);
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;
        Assert.Less(l1, 330);
    }
}


