using System;
using System.Collections.Generic;
using System.Text;

public class Threeuple<T1, T2, T3>
{
    private T1 item1;
    private T2 item2;
    private T3 item3;

    public Threeuple(T1 item1, T2 item2, T3 item3)
    {
        this.item1 = item1;
        this.item2 = item2;
        this.item3 = item3;
    }

    public override string ToString()
    {
        return $"{item1} -> {item2} -> {item3}";
    }
}