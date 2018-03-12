using System;

/// <summary>
/// <para>Product is the entity which your stock data structure
/// will consist of. Please, do not make any modifications as
/// it might lead to unexpected results</para>
/// </summary>
public class Product : IComparable<Product>
{

    public Product(string label, double price, int quantity)
    {
        this.Label = label;
        this.Price = price;
        this.Quantity = quantity;
    }

    public string Label { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public int CompareTo(Product other)
    {
        return this.Label.CompareTo(other.Label);
    }


}