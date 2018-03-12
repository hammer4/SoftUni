using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf05
{
    //RemoveById
    [TestCase]
    public void RemoveById_ShoudlWorkFast()
    {

        IChainblock cb = new Chainblock();
        List<Transaction> txs = new List<Transaction>();
        Random rand = new Random();
        for (int i = 0; i < 100000; i++)
        {
            int amount = rand.Next(0, 40000);
            int status = amount % 4;
            Transaction tx = new Transaction(i, (TransactionStatus)status,
                i.ToString(), i.ToString(), amount);
            cb.Add(tx);
            txs.Add(tx);
        }

        int count = cb.Count;
        Assert.AreEqual(100000, count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Transaction tx in txs)
        {
            cb.RemoveTransactionById(tx.Id);
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;
        Assert.Less(l1, 220);
    }
}


