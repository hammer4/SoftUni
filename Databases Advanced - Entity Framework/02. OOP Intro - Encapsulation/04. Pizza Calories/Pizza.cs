using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
    }

    private string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if(value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public Dough Dough
    {
        set
        {
            this.dough = value;
        }
    }

    public void AddTopping(Topping topping)
    {
        if(this.toppings.Count == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

        this.toppings.Add(topping);
    }

    public double Calories()
    {
        double sum = 0;
        sum += this.dough.Calories();
        this.toppings.ForEach(t => sum += t.Calories());

        return sum;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Calories():f2} Calories.";
    }
}
