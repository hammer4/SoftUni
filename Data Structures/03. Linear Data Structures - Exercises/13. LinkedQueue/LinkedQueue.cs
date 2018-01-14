using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinkedQueue<T>
{
    private class QueueNode<T>
    {
        public T Value { get; private set; }
        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }

        public QueueNode(T value)
        {
            this.Value = value;
        }
    }

    private QueueNode<T> head;
    private QueueNode<T> tail;

    public int Count { get; private set; }

    public void Enqueue(T item)
    {
        if(this.Count == 0)
        {
            this.head = this.tail = new QueueNode<T>(item);
        }
        else
        {
            var oldTail = this.tail;
            this.tail = new QueueNode<T>(item);
            this.tail.PrevNode = oldTail;
            oldTail.NextNode = this.tail;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        T item;
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        else if (this.Count == 1)
        {
            item = this.head.Value;
            this.head = this.tail = null;
        }
        else
        {
            item = this.head.Value;
            this.head = this.head.NextNode;
            this.head.PrevNode = null;
        }

        this.Count--;
        return item;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        var currentNode = this.head;
        int index = 0;

        while(currentNode != null)
        {
            array[index++] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return array;
    }
}
