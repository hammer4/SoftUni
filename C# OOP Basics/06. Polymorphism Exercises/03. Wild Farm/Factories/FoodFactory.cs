using System;
using System.Collections.Generic;
using System.Text;

public static class FoodFactory
{
    public static Food Create(string[] args)
    {
        string type = args[0];
        int quantity = int.Parse(args[1]);
        switch (args[0])
        {
            case nameof(Vegetable):
                return new Vegetable(quantity);
            case nameof(Fruit):
                return new Fruit(quantity);
            case nameof(Meat):
                return new Meat(quantity);
            case nameof(Seeds):
                return new Seeds(quantity);
            default:
                throw new ArgumentException($"{type} is not a valid Food");
        }
    }
}