using System;
using System.Collections.Generic;
using System.Text;

public abstract class Food
{
    public Food(int quantity)
    {
        Quantity = quantity;
    }

    public int Quantity { get; private set; }
}