using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class ProductList
{
    private Dictionary<string, OrderedBag<Product>> byName;
    private Dictionary<string, Bag<Product>> byNameAndProducer;
    private Dictionary<string, OrderedBag<Product>> byProducer;
    private OrderedDictionary<decimal, Bag<Product>> byPrice;

    public ProductList()
    {
        this.byName = new Dictionary<string, OrderedBag<Product>>();
        this.byNameAndProducer = new Dictionary<string, Bag<Product>>();
        this.byProducer = new Dictionary<string, OrderedBag<Product>>();
        this.byPrice = new OrderedDictionary<decimal, Bag<Product>>();
    }

    public void Add(string name, decimal price, string producer)
    {
        var product = new Product(name, price, producer);

        this.byName.AppendValueToKey(name, product);
        this.byNameAndProducer.AppendValueToKey(name + producer, product);
        this.byProducer.AppendValueToKey(producer, product);
        this.byPrice.AppendValueToKey(price, product);

        Console.WriteLine("Product added");
    }

    public int DeleteByProducer(string producer)
    {
        if (!this.byProducer.ContainsKey(producer))
        {
            return 0;
        }

        var productsToDelete = this.byProducer[producer];
        this.byProducer.Remove(producer);
        foreach (var product in productsToDelete)
        {
            this.byName[product.Name].Remove(product);
            this.byNameAndProducer[product.Name + product.Producer].Remove(product);
            this.byPrice[product.Price].Remove(product);
        }

        return productsToDelete.Count;
    }

    public int DeleteByNameProducer(string name, string producer)
    {
        var key = name + producer;
        if (!this.byNameAndProducer.ContainsKey(key))
        {
            return 0;
        }

        var productsToDelete = this.byNameAndProducer[key];
        this.byNameAndProducer.Remove(key);
        foreach (var product in productsToDelete)
        {
            this.byName[product.Name].Remove(product);
            this.byProducer[product.Producer].Remove(product);
            this.byPrice[product.Price].Remove(product);
        }

        return productsToDelete.Count;
    }

    public IEnumerable<Product> FindByName(string name)
    {
        if (!this.byName.ContainsKey(name))
        {
            return Enumerable.Empty<Product>();
        }

        return this.byName[name];
    }

    public IEnumerable<Product> FindByProducer(string producer)
    {
        if (!this.byProducer.ContainsKey(producer))
        {
            return Enumerable.Empty<Product>();
        }

        return this.byProducer[producer];
    }

    public IEnumerable<Product> FindByPrice(decimal from, decimal to)
    {
        var range = this.byPrice.Range(from, true, to, true).Values;

        var result = new OrderedBag<Product>();

        foreach (var bag in range)
        {
            foreach (var product in bag)
            {
                result.Add(product);
            }
        }

        return result;
    }
}