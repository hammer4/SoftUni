using System;
using System.Collections.Generic;

public class Trie<Value>
{
    private Node root;

    private class Node
    {
        public Value val;
        public bool isTerminal;
        public Dictionary<char, Node> next = new Dictionary<char, Node>();
    }

    public Value GetValue(string key)
    {
        var x = GetNode(root, key, 0);
        if (x == null || !x.isTerminal)
        {
            throw new InvalidOperationException();
        }

        return x.val;
    }

    public bool Contains(string key)
    {
        var node = GetNode(this.root, key, 0);
        return node != null && node.isTerminal;
    }

    public void Insert(string key, Value val)
    {
        root = Insert(root, key, val, 0);
    }

    public IEnumerable<string> GetByPrefix(string prefix)
    {
        var results = new Queue<string>();
        var x = GetNode(root, prefix, 0);

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

        if (x.next.ContainsKey(c))
        {
            node = x.next[c];
        }

        return GetNode(node, key, d + 1);
    }

    private Node Insert(Node x, string key, Value val, int d)
    {
        if(x == null)
        {
            x = new Node();
        }

        if(key.Length == d)
        {
            x.isTerminal = true;
            x.val = val;
            return x;
        }

        Node nextNode = null;
        var currentChar = key[d];

        if (x.next.ContainsKey(currentChar))
        {
            nextNode = x.next[currentChar];
        }

        x.next[currentChar] = this.Insert(nextNode, key, val, d + 1);

        return x;
    }

    private void Collect(Node x, string prefix, Queue<string> results)
    {
        if (x == null)
        {
            return;
        }

        if (x.val != null && x.isTerminal)
        {
            results.Enqueue(prefix);
        }

        foreach (var c in x.next.Keys)
        {
            Collect(x.next[c], prefix + c, results);
        }
    }
}