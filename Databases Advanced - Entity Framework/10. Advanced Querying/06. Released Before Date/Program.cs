using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _06._Released_Before_Date
{
    class Program
    {
        public static void Main(string[] args)
        {
            string date = Console.ReadLine();

            using(var context = new BookShopContext())
            {
                Console.WriteLine(GetBooksReleasedBefore(context, date));
            }
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b => b.ReleaseDate < releaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new { b.Title, b.EditionType, b.Price })
                .ToList();

            return String.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}"));
        }
    }
}
