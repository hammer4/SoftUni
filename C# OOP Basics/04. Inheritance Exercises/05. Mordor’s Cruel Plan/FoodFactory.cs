using System;
using System.Collections.Generic;
using System.Text;

public static class FoodFactory
{
    public static Food GenerateFood(string food)
    {
        switch (food.ToLower())
        {
            case "apple":
                return new Apple();
            case "cram":
                return new Cram();
            case "honeycake":
                return new HoneyCake();
            case "lembas":
                return new Lembas();
            case "melon":
                return new Melon();
            case "mushrooms":
                return new Mushrooms();
            default:
                return new Else();
        }
    }
}