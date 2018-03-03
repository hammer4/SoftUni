using System;
using System.Collections.Generic;
using System.Text;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    protected override double WeightPerFood => 0.10;

    public override string ProduceSound()
    {
        return "Squeak";
    }

    protected override void ValidateFood(Food food)
    {
        string type = food.GetType().Name;
        if(type != nameof(Vegetable) && type != nameof(Fruit))
        {
            Throw(food);
        }
    }
    public override string ToString()
    {
        return base.ToString() + $"{Weight + FoodEaten * WeightPerFood}, {LivingRegion}, {FoodEaten}]";
    }
}