using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _14._Increase_Prices
{
    class Program
    {
        public static void Main(string[] args)
        {
            using(var context = new BookShopContext())
            {
                IncreasePrices(context);
            }
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(b => b.Price += 5);

            context.SaveChanges();
        }
    }
}
