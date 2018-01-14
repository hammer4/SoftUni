using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ArrayStack<T>
{
    private T[] elements;
    private const int InitialCapacity = 16;

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }

    public int Count { get; private set; }

    public void Push(T item)
    {
        if(this.Count == this.elements.Length)
        {
            this.Grow();
        }

        this.elements[this.Count] = item;
        this.Count++;
    }

    public T Pop()
    {
        if(this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var item = this.elements[this.Count - 1];
        this.Count--;
        return item;
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];
        Array.Copy(this.elements.Reverse().Skip(this.elements.Length - this.Count).ToArray(), array, this.Count);
        return array;
    }

    private void Grow()
    {
        var newElements = new T[this.elements.Length * 2];
        Array.Copy(this.elements, newElements, this.Count);
        this.elements = newElements;
    }
}