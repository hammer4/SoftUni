using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private OrderedBag<LinkedListNode<T>> byAscending;
    private OrderedBag<LinkedListNode<T>> byDescending;
    private LinkedList<T> byInsertion;

    public FirstLastList()
    {
        this.byInsertion = new LinkedList<T>();
        this.byAscending = new OrderedBag<LinkedListNode<T>>((x, y) => x.Value.CompareTo(y.Value));
        this.byDescending = new OrderedBag<LinkedListNode<T>>((x, y) => y.Value.CompareTo(x.Value));
    }

    public int Count
    {
        get { return this.byInsertion.Count; }
    }

    public void Add(T element)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(element);
        this.byInsertion.AddLast(node);
        this.byAscending.Add(node);
        this.byDescending.Add(node);
    }

    public void Clear()
    {
        this.byInsertion.Clear();
        this.byAscending.Clear();
        this.byDescending.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }

        List<T> result = new List<T>();
        LinkedListNode<T> current = this.byInsertion.First;
        int iter = 0;
        while (iter < count)
        {
            result.Add(current.Value);
            current = current.Next;
            iter++;
        }

        return result;
    }

    public IEnumerable<T> Last(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }
        List<T> result = new List<T>();

        LinkedListNode<T> current = this.byInsertion.Last;
        int iter = 0;
        while (iter < count)
        {
            result.Add(current.Value);
            current = current.Previous;
            iter++;
        }

        return result;
    }

    public IEnumerable<T> Max(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }
        return this.byDescending.Take(count).Select(x => x.Value);
    }

    public IEnumerable<T> Min(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }
        return this.byAscending.Take(count).Select(x => x.Value);
    }

    public int RemoveAll(T element)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(element);
        foreach (var item in this.byAscending.Range(node, true, node, true))
        {
            this.byInsertion.Remove(item);
        }

        int count = this.byAscending.RemoveAllCopies(node);
        this.byDescending.RemoveAllCopies(node);
        return count;
    }

    private bool CountIsInBounds(int count)
    {
        return count >= 0 && count <= this.Count;
    }
}