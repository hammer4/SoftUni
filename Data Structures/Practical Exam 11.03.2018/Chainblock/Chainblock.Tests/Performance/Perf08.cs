using NUnit.Framework;

using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf08
{
    //GetAllOrderedByAmountDescendingThenById
    [TestCase]
    public void GetOrderedByAmountDescendingThenById_ShouldWorkFast()
    {
        IChainblock cb = new Chainblock();
        List<Transaction> txs = new List<Transaction>();
        for (int i = 0; i < 100000; i++)
        {
            Transaction tx = new Transaction(i, TransactionStatus.Successfull,
                i.ToString(), i.ToString(), i);
            cb.Add(tx);
            txs.Add(tx);
        }

        int count = cb.Count;
        Assert.AreEqual(100000, count);
        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Transaction> all = cb.GetAllOrderedByAmountDescendingThenById();
        int c = 0;
        foreach (Transaction tx in all)
        {
            c++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
        Assert.AreEqual(100000, c);
    }
}


