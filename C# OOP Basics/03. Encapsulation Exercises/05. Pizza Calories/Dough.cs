using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Dough
{
    private const int BaseCaloriesPerGram = 2;

    private static object[] allowedFlourTypes = {
        new { FlourType = "white", CaloriesModifier = 1.5 },
        new { FlourType = "wholegrain", CaloriesModifier = 1.0 }
    };

    private static object[] allowedBakingTechniqueTypes = {
        new { BakingTechnique = "crispy", CaloriesModifier = 0.9 },
        new { BakingTechnique = "chewy", CaloriesModifier = 1.1 },
        new { BakingTechnique = "homemade", CaloriesModifier = 1.0 }
    };

    private string flourType;
    private string bakingTechnique;
    private int weight;

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    private string FlourType
    {
        get
        {
            return this.flourType;
        }

        set
        {
            if (!allowedFlourTypes.Any(
                ft => (string)ft.GetType().GetProperty("FlourType").GetValue(ft, null) == value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    private string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }

        set
        {
            if (!allowedBakingTechniqueTypes.Any(
                bt => (string)bt.GetType().GetProperty("BakingTechnique").GetValue(bt, null) == value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
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
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.weight = value;
        }
    }

    public double Calories()
    {
        var ftObject = allowedFlourTypes.First(ft => (string)ft.GetType().GetProperty("FlourType").GetValue(ft, null) == this.FlourType.ToLower());
        var ftModifier = (double)ftObject.GetType().GetProperty("CaloriesModifier").GetValue(ftObject, null);

        var btObject = allowedBakingTechniqueTypes.First(bt => (string)bt.GetType().GetProperty("BakingTechnique").GetValue(bt, null) == this.BakingTechnique.ToLower());
        var btModifier = (double)btObject.GetType().GetProperty("CaloriesModifier").GetValue(btObject, null);

        return BaseCaloriesPerGram * ftModifier * btModifier * this.Weight;
    }
}
