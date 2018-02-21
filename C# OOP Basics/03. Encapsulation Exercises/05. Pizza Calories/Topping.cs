using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Topping
{
    private const int BaseCaloriesPerGram = 2;

    private static object[] allowedToppingTypes = {
        new { ToppingType = "meat", CaloriesModifier = 1.2 },
        new { ToppingType = "veggies", CaloriesModifier = 0.8 },
        new { ToppingType = "cheese", CaloriesModifier = 1.1 },
        new { ToppingType = "sauce", CaloriesModifier = 0.9 }
    };

    private string toppingType;
    private int weight;

    public Topping(string toppingType, int weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    private string ToppingType
    {
        get
        {
            return this.toppingType;
        }

        set
        {
            if (!allowedToppingTypes.Any(
                tt => (string)tt.GetType().GetProperty("ToppingType").GetValue(tt, null) == value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.toppingType = value;
        }
    }

    private int Weight
    {
        get
        {
            return this.weight;
        }

        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double Calories()
    {
        var ttObject = allowedToppingTypes.First(tt => (string)tt.GetType().GetProperty("ToppingType").GetValue(tt, null) == this.ToppingType.ToLower());
        var ttModifier = (double)ttObject.GetType().GetProperty("CaloriesModifier").GetValue(ttObject, null);

        return BaseCaloriesPerGram * ttModifier * this.Weight;
    }
}