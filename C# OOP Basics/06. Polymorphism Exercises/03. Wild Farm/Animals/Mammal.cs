using System;
using System.Collections.Generic;
using System.Text;

public abstract class Mammal : Animal
{
    public Mammal(string name, double weight, string livingRegion) 
        : base(name, weight)
    {
        LivingRegion = livingRegion;
    }

    protected string LivingRegion { get; private set; }
}