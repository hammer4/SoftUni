using System;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
    }

    public void Print(int indent = 0)
    {
        throw new NotImplementedException();
    }

    public void Each(Action<T> action)
    {
        throw new NotImplementedException();
    }
}
