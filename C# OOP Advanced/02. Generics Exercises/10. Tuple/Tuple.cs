using System;
using System.Collections.Generic;
using System.Text;

public class Tuple<T1, T2>
{
    private T1 item1;
    private T2 item2;

    public Tuple(T1 item1, T2 item2)
    {
        this.item1 = item1;
        this.item2 = item2;
    }

    public override string ToString()
    {
        return $"{item1} -> {item2}";
    }
}