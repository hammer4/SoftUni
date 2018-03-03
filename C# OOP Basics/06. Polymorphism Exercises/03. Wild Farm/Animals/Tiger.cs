using System;
using System.Collections.Generic;
using System.Text;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    protected override double WeightPerFood => 1;

    public override string ProduceSound()
    {
        return "ROAR!!!";
    }

    protected override void ValidateFood(Food food)
    {
        if(food.GetType().Name != nameof(Meat))
        {
            Throw(food);
        }
    }
}