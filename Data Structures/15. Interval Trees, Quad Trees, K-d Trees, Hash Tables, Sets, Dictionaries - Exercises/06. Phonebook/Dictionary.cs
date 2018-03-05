using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dictionary<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private HashTable<TKey, TValue> table;

    public Dictionary()
    {
        this.table = new HashTable<TKey, TValue>();
    }

    public int Count { get { return table.Count; } }

    public int Capacity { get { return table.Capacity; } }

    public void Add(TKey key, TValue value)
    {
        table.Add(key, value);
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        return table.AddOrReplace(key, value);
    }

    public TValue Get(TKey key)
    {
        return table.Get(key);
    }

    public TValue this[TKey key]
    {
        get
        {
            return this.table.Get(key);
        }
        set
        {
            this.table.AddOrReplace(key, value);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        return table.TryGetValue(key, out value);
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        return table.Find(key);
    }

    public bool ContainsKey(TKey key)
    {
        return table.ContainsKey(key);
    }

    public bool Remove(TKey key)
    {
        return table.Remove(key);
    }

    public void Clear()
    {
        table.Clear();
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            return this.table.Keys;
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            return this.table.Values;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        return this.table.GetEnumerator();
    }
}