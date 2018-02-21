using System;

public class AVL<T> where T : IComparable<T>
{
    private Node<T> root;

    public Node<T> Root
    {
        get
        {
            return this.root;
        }
    }

    public bool Contains(T item)
    {
        var node = this.Search(this.root, item);
        return node != null;
    }

    public void Insert(T item)
    {
        this.root = this.Insert(this.root, item);
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private Node<T> Insert(Node<T> node, T item)
    {
        if (node == null)
        {
            return new Node<T>(item);
        }

        int cmp = item.CompareTo(node.Value);
        if (cmp < 0)
        {
            node.Left = this.Insert(node.Left, item);
        }
        else if (cmp > 0)
        {
            node.Right = this.Insert(node.Right, item);
        }


        node = this.Balance(node);


        return node;
    }
    public void Delete(int item)
    {
        this.root = Delete(this.root, item);
    }

    private Node<T> Delete(Node<T> node, int item)
    {
        if (node == null)
        {
            return null;
        }

        var cmp = item.CompareTo(node.Value);

        if (cmp < 0)
        {
            node.Left = this.Delete(node.Left, item);
        }
        else if (cmp > 0)
        {
            node.Right = Delete(node.Right, item);
        }
        else
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }
            else
            {
                var min = this.GetMin(node.Right);


                min.Right = this.DeleteMin(node.Right);
                min.Left = node.Left;
                node = min;
            }
        }

        node = this.Balance(node);
        return node;
    }

    public Node<T> GetMin(Node<T> node)
    {
        if (node == null)
        {
            return null;
        }

        if (node.Left == null)
        {
            return node;
        }

        return this.GetMin(node.Left);
    }

    public void DeleteMin()
    {
        this.root = this.DeleteMin(this.root);
    }

    private Node<T> DeleteMin(Node<T> node)
    {
        if (node == null)
        {
            return null;
        }

        if (node.Left == null)
        {
            return node.Right;
        }

        node.Left = this.DeleteMin(node.Left);
        node = this.Balance(node);


        return node;
    }

    private Node<T> Balance(Node<T> node)
    {
        int balance = Height(node.Left) - Height(node.Right);

        if (balance < -1)
        {
            balance = Height(node.Right.Left) - Height(node.Right.Right);

            if (balance > 0)
            {
                node.Right = RotateRight(node.Right);
            }

            return RotateLeft(node);
        }
        else if (balance > 1)
        {
            balance = Height(node.Left.Left) - Height(node.Left.Right);

            if (balance < 0)
            {
                node.Left = RotateLeft(node.Left);
            }

            return RotateRight(node);
        }
        this.UpdateHeight(node);
        return node;
    }

    private void UpdateHeight(Node<T> node)
    {
        node.Height = Math.Max(this.Height(node.Left), this.Height(node.Right)) + 1;
    }

    private Node<T> Search(Node<T> node, T item)
    {
        if (node == null)
        {
            return null;
        }

        int cmp = item.CompareTo(node.Value);
        if (cmp < 0)
        {
            return Search(node.Left, item);
        }
        else if (cmp > 0)
        {
            return Search(node.Right, item);
        }

        return node;
    }

    private void EachInOrder(Node<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private int Height(Node<T> node)
    {
        if (node == null)
        {
            return 0;
        }
        return node.Height;
    }

    private Node<T> RotateRight(Node<T> node)
    {
        var left = node.Left;
        node.Left = left.Right;
        left.Right = node;

        this.UpdateHeight(node);
        this.UpdateHeight(left);
        return left;

    }
    private Node<T> RotateLeft(Node<T> node)
    {
        var right = node.Right;
        node.Right = right.Left;
        right.Left = node;

        this.UpdateHeight(node);
        this.UpdateHeight(right);

        return right;

    }
}