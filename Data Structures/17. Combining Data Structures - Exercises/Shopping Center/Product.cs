using System;

public class Product : IComparable<Product>
{
    public Product(string name, decimal price, string producer)
    {
        this.Name = name;
        this.Price = price;
        this.Producer = producer;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Producer { get; set; }

    public int CompareTo(Product other)
    {
        var cmp = this.Name.CompareTo(other.Name);
        if (cmp == 0) cmp = this.Producer.CompareTo(other.Producer);
        if (cmp == 0) cmp = this.Price.CompareTo(other.Price);

        return cmp;
    }

    public override string ToString()
    {
        return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
    }
}