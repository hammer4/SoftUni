using System;
using System.Collections.Generic;
using System.Text;

public abstract class Bird : Animal
{
    public Bird(string name, double weight, double wingSize) 
        : base(name, weight)
    {
        WingSize = wingSize;
    }

    private double WingSize { get; set; }

    public override string ToString()
    {
        return base.ToString() + $"{WingSize}, {Weight + FoodEaten * WeightPerFood}, {FoodEaten}]";
    }
}