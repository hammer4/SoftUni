using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T>
    where T : IComparable<T>
{
    private List<T> data;

    public CustomList()
    {
        this.data = new List<T>();
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove(int index)
    {
        T element = this.data[index];
        this.data.RemoveAt(index);

        return element;
    }

    public bool Contains(T element)
    {
        return this.data.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        T temp = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        return this.data.Count(e => e.CompareTo(element) > 0);
    }

    public T Max()
    {
        return this.data.Max();
    }

    public T Min()
    {
        return this.data.Min();
    }

    public override string ToString()
    {
        return String.Join(Environment.NewLine, this.data);
    }
}