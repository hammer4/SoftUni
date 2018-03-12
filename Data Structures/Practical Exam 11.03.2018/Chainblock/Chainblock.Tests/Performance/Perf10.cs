using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[TestFixture]
public class Perf10
{
    //GetByReceiverOrderedByAmountThenById
    [TestCase]
    public void GetByReceiverOrderedByAmountThenById_ShouldWorkFast()
    {
        IChainblock cb = new Chainblock();
        List<Transaction> txs = new List<Transaction>();
        for (int i = 0; i < 100000; i++)
        {
            Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                i.ToString(), "to", i);
            cb.Add(tx);
            txs.Add(tx);
        }

        int count = cb.Count;
        txs = txs.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
        Assert.AreEqual(100000, count);
        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Transaction> all = cb.GetByReceiverOrderedByAmountThenById("to");
        int c = 0;
        foreach (Transaction tx in all)
        {
            Assert.AreSame(tx, txs[c]);
            c++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 200);
        Assert.AreEqual(100000, c);
    }
}


