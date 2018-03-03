using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal
{
    public Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    protected abstract double WeightPerFood { get; }

    private string Name { get; set; }

    protected double Weight { get ; private set; }

    protected int FoodEaten { get; set; }

    public abstract string ProduceSound();

    public virtual void EatFood(Food food)
    {
        ValidateFood(food);

        this.FoodEaten += food.Quantity;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, ";
    }

    protected void Throw(Food food)
    {
        throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
    }

    protected abstract void ValidateFood(Food food);
}