using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<Product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    private decimal Money
    {
        set
        {
            if(value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public IReadOnlyCollection<Product> Products
    {
        get
        {
            return this.products;
        }
    }

    public bool BuyProduct(Product product)
    {
        if(this.money >= product.Cost)
        {
            this.money -= product.Cost;
            this.products.Add(product);
            return true;
        }

        return false;
    }
}