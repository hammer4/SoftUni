using System;
using System.Collections.Generic;
using System.Text;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    protected override double WeightPerFood => 0.30;

    public override string ProduceSound()
    {
        return "Meow";
    }

    protected override void ValidateFood(Food food)
    {
        string type = food.GetType().Name;

        if(type != nameof(Vegetable) && type != nameof(Meat))
        {
            Throw(food);
        }
    }
}