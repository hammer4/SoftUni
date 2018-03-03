using System;
using System.Collections.Generic;
using System.Text;

public abstract class Feline : Mammal
{
    public Feline(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion)
    {
        Breed = breed;
    }

    private string Breed { get; set; }

    public override string ToString()
    {
        return base.ToString() + $"{Breed}, {Weight + FoodEaten * WeightPerFood}, {LivingRegion}, {FoodEaten}]";
    }
}