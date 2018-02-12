using System;
using System.Collections.Generic;
using System.Collections;

public class Hierarchy<T> : IHierarchy<T>
{
    private Dictionary<T, Node> nodesByValues;
    private class Node
    {
        public T Value { get; private set; }
        public List<Node> Children { get; set; }
        public Node Parent { get; set; }

        public Node(T value, Node parent)
        {
            this.Value = value;
            this.Children = new List<Node>();
            this.Parent = parent;
        }
    }
    private Node root;

    public Hierarchy(T root)
    {
        this.root = new Node(root, null);
        this.nodesByValues = new Dictionary<T, Node>() { [root] = this.root };
    }

    public int Count
    {
        get
        {
            return this.nodesByValues.Count;
        }
    }

    public void Add(T element, T child)
    {
        if (this.nodesByValues.ContainsKey(child) || !this.nodesByValues.ContainsKey(element))
        {
            throw new ArgumentException();
        }

        var newNode = new Node(child, this.nodesByValues[element]);
        this.nodesByValues[element].Children.Add(newNode);
        this.nodesByValues[child] = newNode;
    }

    public void Remove(T element)
    {
        if (!this.nodesByValues.ContainsKey(element))
        {
            throw new ArgumentException();
        }

        if (this.nodesByValues[element].Parent == null)
        {
            throw new InvalidOperationException();
        }

        var parent = this.nodesByValues[element].Parent;
        var children = this.nodesByValues[element].Children;

        children.ForEach(c => c.Parent = parent);
        parent.Children.Remove(nodesByValues[element]);
        parent.Children.AddRange(children);

        this.nodesByValues.Remove(element);
    }

    public IEnumerable<T> GetChildren(T item)
    {
        if (!this.nodesByValues.ContainsKey(item))
        {
            throw new ArgumentException();
        }

        List<T> children = new List<T>();

        this.nodesByValues[item].Children.ForEach(c => children.Add(c.Value));

        return children;
    }

    public T GetParent(T item)
    {
        if (!this.nodesByValues.ContainsKey(item))
        {
            throw new ArgumentException();
        }

        if (this.nodesByValues[item].Parent == null)
        {
            return default(T);
        }

        return this.nodesByValues[item].Parent.Value;
    }

    public bool Contains(T value)
    {
        return this.nodesByValues.ContainsKey(value);
    }

    public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
    {
        var list = new List<T>();

        foreach (var key in this.nodesByValues.Keys)
        {
            if (other.nodesByValues.ContainsKey(key))
            {
                list.Add(key);
            }
        }

        return list;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var queue = new Queue<T>();
        queue.Enqueue(this.root.Value);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            foreach (var child in this.nodesByValues[current].Children)
            {
                queue.Enqueue(child.Value);
            }

            yield return current;
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

}