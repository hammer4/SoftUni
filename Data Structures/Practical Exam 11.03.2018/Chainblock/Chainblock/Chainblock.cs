using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Chainblock : IChainblock
{
    private Dictionary<int, Transaction> byId = new Dictionary<int, Transaction>();
    private Dictionary<TransactionStatus, HashSet<Transaction>> byStatus = new Dictionary<TransactionStatus, HashSet<Transaction>>();

    public int Count => this.byId.Count;

    public void Add(Transaction tx)
    {
        byId.Add(tx.Id, tx);

        if (!byStatus.ContainsKey(tx.Status))
        {
            byStatus[tx.Status] = new HashSet<Transaction>();
        }

        byStatus[tx.Status].Add(tx);
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        if (!byId.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        var tr = byId[id];
        byStatus[tr.Status].Remove(tr);

        tr.Status = newStatus;


        if (!byStatus.ContainsKey(newStatus))
        {
            byStatus[newStatus] = new HashSet<Transaction>();
        }

        byStatus[newStatus].Add(tr);
    }


    public bool Contains(Transaction tx)
    {
        return this.byId.ContainsKey(tx.Id);
    }

    public bool Contains(int id)
    {
        return this.byId.ContainsKey(id);
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        return this.byId.Values
            .Where(t => t.Amount >= lo && t.Amount <= hi);
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        return byId.Values.OrderByDescending(t => t.Amount)
            .ThenBy(t => t.Id);
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        if (!byStatus.ContainsKey(status))
        {
            throw new InvalidOperationException();
        }

        var query = this.byStatus[status]
            .OrderByDescending(t => t.Amount)
            .Select(t => t.To);

        if (!query.Any())
        {
            throw new InvalidOperationException();
        }

        return query;
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        if (!byStatus.ContainsKey(status))
        {
            throw new InvalidOperationException();
        }
        var query = this.byStatus[status]
            .OrderByDescending(t => t.Amount)
            .Select(t => t.From);

        if (!query.Any())
        {
            throw new InvalidOperationException();
        }

        return query;
    }

    public Transaction GetById(int id)
    {
        if (!byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        return byId[id];
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        var query = byId.Values
            .Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi)
            .OrderByDescending(t => t.Amount)
            .ThenBy(t => t.Id);

        if(query.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return query;
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        var query = byId.Values
            .Where(t => t.To == receiver)
            .OrderByDescending(t => t.Amount)
            .ThenBy(t => t.Id);

        if(query.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return query;
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        var query = byId.Values
            .Where(t => t.From == sender && t.Amount > amount)
            .OrderByDescending(t => t.Amount);

        if(query.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return query;
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        var query = byId.Values
            .Where(t => t.From == sender)
            .OrderByDescending(t => t.Amount);

        if(query.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return query;
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        if (!byStatus.ContainsKey(status))
        {
            throw new InvalidOperationException();
        }

        return byStatus[status].OrderByDescending(t => t.Amount);
    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        if (byStatus.ContainsKey(status))
        {
            return byStatus[status]
                .Where(t => t.Amount <= amount)
                .OrderByDescending(t => t.Amount);
        }

        return Enumerable.Empty<Transaction>();
    }

    public IEnumerator<Transaction> GetEnumerator()
    {
        foreach (var t in byId.Values)
        {
            yield return t;
        }
    }

    public void RemoveTransactionById(int id)
    {
        if (!byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        var tr = byId[id];
        byId.Remove(id);
        byStatus[tr.Status].Remove(tr);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

