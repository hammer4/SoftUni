using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _12._Profit_by_Category
{
    class Program
    {
        public static void Main(string[] args)
        {
            using(var context = new BookShopContext())
            {
                Console.WriteLine(GetTotalProfitByCategory(context));
            }
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitsByCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Select(cb => cb.Book.Copies * cb.Book.Price).Sum()
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            return String.Join(Environment.NewLine, profitsByCategory.Select(p => $"{p.Name} ${p.Profit:f2}"));
        }
    }
}
