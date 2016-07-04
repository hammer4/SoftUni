using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Pizza_Calories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if(value == string.Empty || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            private get
            {
                return this.dough;
            }

            set
            {
                this.dough = value;
            }
        }

        public int GetNumberOfToppings()
        {
            return this.toppings.Count;
        }

        public void AddTopping(Topping topping)
        {
            if(this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }

        public double Callories()
        {
            double callories = 0;
            callories += this.dough.Callories();
            foreach(Topping topping in this.toppings)
            {
                callories += topping.Callories();
            }

            return callories;
        }
    }
}
