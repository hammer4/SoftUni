using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReversedList<T> : IEnumerable<T>
{
    private T[] elements;

    public ReversedList()
    {
        this.Capacity = 2;
        this.elements = new T[this.Capacity];
    }

    public int Count { get; set; }
    public int Capacity { get; set; }

    public void Add(T item)
    {
        if(this.Count == this.Capacity)
        {
            this.Grow();
        }

        this.elements[this.Count] = item;
        this.Count++;
    }

    public T this[int index]
    {
        get
        {
            if(index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            return this.elements[this.Count - index - 1];
        }

        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            this.elements[this.Count - index - 1] = value;
        }
    }

    public T RemoveAt(int index)
    {
        if(index < 0 || index >= this.Count)
        {
            throw new IndexOutOfRangeException();
        }

        T element = this[index];
        
        for(int i = this.Count - index - 1; i < this.Count -1; i++)
        {
            this.elements[i] = this.elements[i + 1];
        }

        this.Count--;

        return element;
    }

    private void Grow()
    {
        var newElements = new T[this.Capacity * 2];
        Array.Copy(this.elements, newElements, this.Count);
        this.Capacity *= 2;
        this.elements = newElements;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(int i=this.Count-1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}