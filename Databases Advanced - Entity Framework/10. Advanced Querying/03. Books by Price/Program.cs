using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _03._Books_by_Price
{
    class Program
    {
        public static void Main(string[] args)
        {
            using(var context = new BookShopContext())
            {
                Console.WriteLine(GetBooksByPrice(context));
            }
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { b.Title, b.Price })
                .ToList();

            return String.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:f2}"));
        }
    }
}
