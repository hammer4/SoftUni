using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BalancedOrderedSet<T> : IEnumerable<T> where T : IComparable<T>
{
    private AVL<T> data;

    public BalancedOrderedSet()
    {
        this.data = new AVL<T>();
    }

    public int Count { get { return this.data.Count; } }

    public void Add(T element)
    {
        this.data.Insert(element);
    }

    public bool Contains(T element)
    {
        return this.data.Contains(element);
    }

    public void Remove(T element)
    {
        this.data.Delete(element);
    }

    public IEnumerator<T> GetEnumerator()
    {
        var list = new List<T>();

        this.data.EachInOrder(list.Add);

        foreach(var element in list)
        {
            yield return element;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}