using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf06
{
    //GetById
    [TestCase]
    public void GetById_ShouldWorkFast()
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
        for (int i = 0; i < 100000; i++)
        {
            int status = rand.Next(0, 4);
            Transaction tx = new Transaction(i, statuses[status],
                i.ToString(), i.ToString(), i);
            cb.Add(tx);
            txs.Add(tx);
        }

        int count = cb.Count;
        Assert.AreEqual(100000, count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Transaction tx in txs)
        {
            Assert.AreSame(tx, cb.GetById(tx.Id));
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
    }
}


