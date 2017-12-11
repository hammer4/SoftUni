using System;
using FastFood.Data;
using System.Linq;

namespace FastFood.DataProcessor
{
    public static class Bonus
    {
	    public static string UpdatePrice(FastFoodDbContext context, string itemName, decimal newPrice)
	    {
            var item = context.Items.FirstOrDefault(i => i.Name == itemName);

            if(item == null)
            {
                string err = $"Item {itemName} not found!";
                return err;
            }

            var old = item.Price;
            item.Price = newPrice;
            context.SaveChanges();

            string succ = $"{item.Name} Price updated from ${old} to ${newPrice:f2}";
            return succ;
	    }
    }
}
