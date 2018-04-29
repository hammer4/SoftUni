using System;
using System.Collections.Generic;

public class PriorityQueue<T> where T : IComparable<T>
{
    private Dictionary<T, int> searchCollection;
    private List<T> heap;

    public PriorityQueue()
    {
        this.heap = new List<T>();
        this.searchCollection = new Dictionary<T, int>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public T ExtractMin()
    {
        var min = this.heap[0];
        this.heap[0] = this.heap[this.heap.Count - 1];
        this.heap.RemoveAt(this.heap.Count - 1);
        if (this.heap.Count > 0)
        {
            this.HeapifyDown(0);
        }

        this.searchCollection.Remove(min);

        return min;
    }

    public T PeekMin()
    {
        return this.heap[0];
    }

    public void Enqueue(T element)
    {
        this.searchCollection.Add(element, this.heap.Count);
        this.heap.Add(element);
        this.HeapifyUp(this.heap.Count - 1);
    }

    private void HeapifyDown(int i)
    {
        var left = (2 * i) + 1;
        var right = (2 * i) + 2;
        var smallest = i;

        if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
        {
            smallest = left;
        }

        if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
        {
            smallest = right;
        }

        if (smallest != i)
        {
            T old = this.heap[i];
            this.searchCollection[old] = smallest;
            this.searchCollection[this.heap[smallest]] = i;
            this.heap[i] = this.heap[smallest];
            this.heap[smallest] = old;
            this.HeapifyDown(smallest);
        }
    }

    private void HeapifyUp(int i)
    {
        var parent = (i - 1) / 2;
        while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
        {
            T old = this.heap[i];
            this.searchCollection[old] = parent;
            this.searchCollection[this.heap[parent]] = i;
            this.heap[i] = this.heap[parent];
            this.heap[parent] = old;

            i = parent;
            parent = (i - 1) / 2;
        }
    }

    public void DecreaseKey(T element)
    {
        int index = this.searchCollection[element];
        this.HeapifyUp(index);
    }
}