using System;
using System.Collections.Generic;

public class Trie<Value>
{
    private Node root;

    private class Node
    {
        public Value Val;
        public bool IsTerminal;
        public Dictionary<char, Node> Next = new Dictionary<char, Node>();
    }

    public Value GetValue(string key)
    {
        Node x = this.GetNode(this.root, key, 0);
        if (x == null || !x.IsTerminal)
        {
            throw new InvalidOperationException();
        }

        return x.Val;
    }

    public bool Contains(string key)
    {
        Node node = this.GetNode(this.root, key, 0);
        return node != null && node.IsTerminal;
    }

    public void Insert(string key, Value val)
    {
        this.root = this.Insert(this.root, key, val, 0);
    }

    public IEnumerable<string> GetByPrefix(string prefix)
    {
        Queue<string> results = new Queue<string>();
        Node x = this.GetNode(this.root, prefix, 0);

        this.Collect(x, prefix, results);

        return results;
    }

    private Node GetNode(Node x, string key, int d)
    {
        if (x == null)
        {
            return null;
        }

        if (d == key.Length)
        {
            return x;
        }

        Node node = null;
        char c = key[d];

        if (x.Next.ContainsKey(c))
        {
            node = x.Next[c];
        }

        return this.GetNode(node, key, d + 1);
    }

    private Node Insert(Node x, string key, Value val, int d)
    {
        if (x == null)
        {
            x = new Node();
        }

        if (d == key.Length)
        {
            x.Val = val;
            x.IsTerminal = true;
            return x;
        }

        Node node = null;
        char c = key[d];

        if (x.Next.ContainsKey(c))
        {
            node = x.Next[c];
        }

        x.Next[c] = this.Insert(node, key, val, d + 1);
        return x;
    }

    private void Collect(Node x, string prefix, Queue<string> results)
    {
        if (x == null)
        {
            return;
        }

        if (x.Val != null && x.IsTerminal)
        {
            results.Enqueue(prefix);
        }

        foreach (char c in x.Next.Keys)
        {
            this.Collect(x.Next[c], prefix + c, results);
        }
    }
}