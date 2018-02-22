using System;
using System.Collections.Generic;

public class IntervalTree
{
    private class Node
    {
        internal Interval interval;
        internal double max;
        internal Node right;
        internal Node left;

        public Node(Interval interval)
        {
            this.interval = interval;
            this.max = interval.Hi;
        }
    }

    private Node root;

    public void Insert(double lo, double hi)
    {
        this.root = this.Insert(this.root, lo, hi);
    }

    public void EachInOrder(Action<Interval> action)
    {
        EachInOrder(this.root, action);
    }

    public Interval SearchAny(double lo, double hi)
    {
        Node current = this.root;
        while (current != null
               && !current.interval.Intersects(lo, hi))
        {
            if (current.left != null && current.left.max > lo)
            {
                current = current.left;
            }
            else
            {
                current = current.right;
            }
        }

        return current?.interval;
    }

    public IEnumerable<Interval> SearchAll(double lo, double hi)
    {
        List<Interval> result = new List<Interval>();
        if (this.root == null)
        {
            return result;
        }
        this.SearchAll(this.root, result, new Interval(lo, hi));
        return result;
    }

    private void SearchAll(Node node, List<Interval> result, Interval i)
    {

        if (node.left != null && node.left.max > i.Lo)
        {
            this.SearchAll(node.left, result, i);
        }

        if (node.interval.Intersects(i))
        {
            result.Add(node.interval);
        }

        if (node.right != null && node.right.interval.Lo < i.Hi)
        {
            this.SearchAll(node.right, result, i);
        }

    }

    private void EachInOrder(Node node, Action<Interval> action)
    {
        if (node == null)
        {
            return;
        }

        EachInOrder(node.left, action);
        action(node.interval);
        EachInOrder(node.right, action);
    }

    private Node Insert(Node node, double lo, double hi)
    {
        if (node == null)
        {
            return new Node(new Interval(lo, hi));
        }

        int cmp = lo.CompareTo(node.interval.Lo);
        if (cmp < 0)
        {
            node.left = Insert(node.left, lo, hi);
        }
        else if (cmp > 0)
        {
            node.right = Insert(node.right, lo, hi);
        }

        this.UpdateMax(node);

        return node;
    }

    private void UpdateMax(Node node)
    {
        double max = Math.Max(this.GetMax(node.left)
            , this.GetMax(node.right));

        node.max = Math.Max(max, node.max);
    }

    private double GetMax(Node node)
    {
        if (node == null)
        {
            return 0d;
        }
        return node.max;
    }
}
