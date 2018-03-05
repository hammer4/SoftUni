using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OrderedSet<T> : IEnumerable<T> where T : IComparable
{
    private BinarySearchTree<T> data;

    public OrderedSet()
    {
        this.data = new BinarySearchTree<T>();
    }

    public int Count { get { return this.data.Count(); } }

    public void Add(T element)
    {
        this.data.Insert(element);
    }

    public bool Contains(T element)
    {
        return this.data.Contains(element);
    }

    public void Remove (T element)
    {
        this.data.Delete(element);
    }

    public IEnumerator<T> GetEnumerator()
    {
        var elements = new List<T>();

        this.data.EachInOrder(elements.Add);

        foreach(var element in elements)
        {
            yield return element;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}