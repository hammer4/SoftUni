using System;
using System.Collections.Generic;
using System.Text;

public abstract class Item
{
    public string Key { get; protected set; }
    public long Value { get; protected set; }

    public void IncreaseValue(long value)
    {
        Value += value;
    }
}
