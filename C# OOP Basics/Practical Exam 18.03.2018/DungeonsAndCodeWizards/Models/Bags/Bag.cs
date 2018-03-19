using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Bag
{
    private int capacity;
    private List<Item> items;

    protected Bag(int capacity = 100)
    {
        this.Capacity = capacity;
        this.items = new List<Item>();
    }

    public IReadOnlyCollection<Item> Items
    {
        get { return items; }
    }


    public int Load { get { return this.Items.Sum(i => i.Weight); } }

    public int Capacity
    {
        get { return capacity; }
        private set { capacity = value; }
    }

    public void AddItem(Item item)
    {
        if(Load + item.Weight > Capacity)
        {
            throw new InvalidOperationException("Bag is full!");
        }

        this.items.Add(item);
    }

    public Item GetItem(string name)
    {
        if(Items.Count == 0)
        {
            throw new InvalidOperationException("Bag is empty!");
        }

        var item = Items.FirstOrDefault(i => i.GetType().Name == name);

        if(item == null)
        {
            throw new ArgumentException($"No item with name {name} in bag!");
        }

        this.items.Remove(item);

        return item;
    }
}