using System;

public class BinaryTree<T>
{
    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        throw new NotImplementedException();
    }

    public void EachInOrder(Action<T> action)
    {
        throw new NotImplementedException();
    }

    public void EachPostOrder(Action<T> action)
    {
        throw new NotImplementedException();
    }
}
