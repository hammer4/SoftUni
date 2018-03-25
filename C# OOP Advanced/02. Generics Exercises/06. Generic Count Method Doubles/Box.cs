using System;
using System.Collections.Generic;
using System.Text;

public class Box<T> : IComparable<T>
    where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public int CompareTo(T other)
    {
        return this.value.CompareTo(other);
    }

    public override string ToString()
    {
        return $"{this.value.GetType().FullName}: {this.value}";
    }
}