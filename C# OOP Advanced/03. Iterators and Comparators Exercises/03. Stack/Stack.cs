using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class Stack<T> : IEnumerable<T>
{
    private List<T> elements;
    private int currentIndex = -1;

    public Stack()
    {
        this.elements = new List<T>();
    }

    public void Push(params T[] items)
    {
        foreach(var item in items)
        {
            elements.Insert(++currentIndex, item);
        }
    }

    public void Pop()
    {
        if(currentIndex < 0)
        {
            throw new InvalidOperationException("No elements");
        }

        currentIndex--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(int i= currentIndex; i >= 0; i--)
        {
            yield return elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}