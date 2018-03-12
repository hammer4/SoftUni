using System;
using System.Collections.Generic;

public interface IChainblock : IEnumerable<Transaction>
{

    int Count { get; }

    void Add(Transaction tx);
    bool Contains(Transaction tx);
    bool Contains(int id);

    void ChangeTransactionStatus(int id, TransactionStatus newStatus);
    void RemoveTransactionById(int id);

    Transaction GetById(int id);

    IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status);
    IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status);
    IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status);

    IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById();
    IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender);
    IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver);

    IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount);
    IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount);
    IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi);

    IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi);
}

