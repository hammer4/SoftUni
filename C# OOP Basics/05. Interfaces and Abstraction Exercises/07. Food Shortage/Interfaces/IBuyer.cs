using System;
using System.Collections.Generic;
using System.Text;

public interface IBuyer
{
    string Name { get; }

    int Food { get; }

    void BuyFood();
}