using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return $"{this.value.GetType().FullName}: {this.value}";
    }
}