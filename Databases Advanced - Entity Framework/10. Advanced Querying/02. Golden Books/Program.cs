using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _02._Golden_Books
{
    class Program
    {
        public static void Main(string[] args)
        {
            using(var context = new BookShopContext())
            {
                Console.WriteLine(GetGoldenBooks(context));
            }
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var booksTitles = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksTitles);
        }
    }
}
