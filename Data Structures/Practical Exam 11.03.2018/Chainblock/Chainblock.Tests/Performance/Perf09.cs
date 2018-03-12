using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[TestFixture]
public class Perf09
{
    //GetBySenderOrderedByAmountDescending
    [TestCase]
    public void GetBySenderOrderedByAmountDescending_ShouldWorkFast()
    {
        IChainblock cb = new Chainblock();
        List<Transaction> txs = new List<Transaction>();
        for (int i = 0; i < 100000; i++)
        {
            Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                "sender", i.ToString(), i);
            cb.Add(tx);
            txs.Add(tx);
        }

        int count = cb.Count;
        txs = txs.OrderByDescending(x => x.Amount).ToList();
        Assert.AreEqual(100000, count);
        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Transaction> all = cb.GetBySenderOrderedByAmountDescending("sender");
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


