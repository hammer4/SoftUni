using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinkedStack<T>
{
    private class Node<T>
    {
        public T value;
        public Node<T> NextNode { get; set; }
        public Node(T value, Node<T> nextNode)
        {
            this.value = value;
            this.NextNode = nextNode;
        }
    }

    private Node<T> firstNode;

    public int Count { get; set; }

    public void Push(T element)
    {
        this.firstNode = new Node<T>(element, this.firstNode);
        this.Count++;
    }

    public T Pop()
    {
        if(this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var item = this.firstNode.value;
        this.firstNode = this.firstNode.NextNode;
        this.Count--;
        return item;
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];
        var currentNode = this.firstNode;
        int index = 0;

        while(currentNode != null)
        {
            array[index] = currentNode.value;
            index++;
            currentNode = currentNode.NextNode;
        }

        return array;
    }
}