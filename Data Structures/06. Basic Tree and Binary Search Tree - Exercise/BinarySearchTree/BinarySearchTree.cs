using System;
using System.Collections.Generic;

public class BinarySearchTree<T> : IBinarySearchTree<T> where T:IComparable
{
    private Node root;

    private Node FindElement(T element)
    {
        Node current = this.root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    private void PreOrderCopy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.PreOrderCopy(node.Left);
        this.PreOrderCopy(node.Right);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right);
        }

        return node;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (nodeInHigherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
    }
    
    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private BinarySearchTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
    }
    
    public void Insert(T element)
    {
        this.root = this.Insert(element, this.root);
    }
    
    public bool Contains(T element)
    {
        Node current = this.FindElement(element);

        return current != null;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        Node current = this.root;
        Node parent = null;
        while (current.Left != null)
        {
            parent = current;
            current = current.Left;
        }

        if (parent == null)
        {
            this.root = this.root.Right;
        }
        else
        {
            parent.Left = current.Right;
        }
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    public void Delete(T element)
    {
        if (!this.Contains(element))
        {
            throw new InvalidOperationException();
        }

        if(this.Count(this.root) == 1)
        {
            this.root = null;
            return;
        }

        Node node = this.root;
        Node parent = null;

        while(node.Value.CompareTo(element) != 0)
        {
            parent = node;

            if(node.Value.CompareTo(element) > 0)
            {
                node = node.Left;
            }
            else
            {
                node = node.Right;
            }
        }

        if(node.Left == null && node.Right == null)
        {
            if(parent.Left.Value.CompareTo(element) == 0)
            {
                parent.Left = null;
            }
            else
            {
                parent.Right = null;
            }

            return;
        }

        if(node.Right == null)
        {
            if(parent.Left.Value.CompareTo(element) == 0)
            {
                parent.Left = node.Left;
            }
            else
            {
                parent.Right = node.Left;
            }

            return;
        }


        if(node.Right.Left == null)
        {
            if(parent.Left.Value.CompareTo(element) == 0)
            {
                parent.Left = node.Right;
                node.Right.Left = node.Left;
            }
            else
            {
                parent.Right = node.Right;
                node.Right.Left = node.Left;
            }

            return;
        }

        if(node.Right.Left != null)
        {
            Node min = node.Right.Left;
            Node minParent = node.Right;

            while(min.Left != null)
            {
                minParent = min;
                min = min.Left;
            }

            if (minParent.Left.Value.CompareTo(min.Value) == 0)
            {
                minParent.Left = null;
            }
            else
            {
                minParent.Right = null;
            }

            if (parent.Left.Value.CompareTo(element) == 0)
            {
                parent.Left = min;
                min.Left = node.Left;
                min.Right = node.Right;
               
            }
            else
            {
                parent.Right = min;
                min.Right = node.Right;
                min.Left = node.Left;
            }
        }
    }

    public void DeleteMax()
    {
        Node parent = null;
        Node current = this.root;

        if(current == null)
        {
            throw new InvalidOperationException();
        }

        while(current.Right != null)
        {
            parent = current;
            current = current.Right;
        }

        if(parent != null)
        {
            parent.Right = current.Left;
        }
        else
        {
            this.root = this.root.Left;
        }
    }

    public int Count()
    {
        return this.Count(this.root);
    }

    private int Count(Node node, int sum=1)
    {
        if(node != null)
        {
            sum += this.Count(node.Left, sum) + this.Count(node.Right, sum);
            return sum;
        }
        else
        {
            return 0;
        }
    }

    public int Rank(T element)
    {
        int rank = this.Rank(element, this.root);
        return rank;
    }

    private int Rank(T element, Node node)
    {
        if(node == null)
        {
            return 0;
        }

        int compare = element.CompareTo(node.Value);

        if(compare < 0)
        {
            return this.Rank(element, node.Left);
        }

        if(compare > 0)
        {
            return 1 + this.Count(node.Left) + this.Rank(element, node.Right);
        }

        return this.Count(node.Left);
    }

    public T Select(int rank)
    {
        if(this.Count(this.root) <= rank)
        {
            throw new InvalidOperationException();
        }

        T value = this.Select(rank, this.root);
        return value;
    }

    private T Select(int targetRank, Node node)
    {
        int rank = this.Rank(node.Value);
        int compare = rank.CompareTo(targetRank);

        if(compare > 0)
        {
            return this.Select(targetRank, node.Left);
        }
        else if(compare < 0)
        {
            return this.Select(targetRank, node.Right);
        }

        return node.Value;
    }

    public T Ceiling(T element)
    {
        return this.Select(this.Rank(element) + 1);
    }

    public T Floor(T element)
    {
        if (!this.Contains(element))
        {
            throw new InvalidOperationException();
        }
        
        return this.Select(this.Rank(element) - 1);
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Count { get; set; }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(3);
        bst.Insert(5);
        bst.Insert(1);

        bst.Delete(1);


        bst.EachInOrder(Console.WriteLine);
        
    }
}