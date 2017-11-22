using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _04._Not_Released_In
{
    class Program
    {
        public static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());

            using(var context = new BookShopContext())
            {
                Console.WriteLine(GetBooksNotRealeasedIn(context, year));
            }
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var booksTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksTitles);
        }
    }
}
