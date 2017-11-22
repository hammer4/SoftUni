using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _08._Book_Search
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            using(var context = new BookShopContext())
            {
                Console.WriteLine(GetBookTitlesContaining(context, input));
            }
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var booksTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksTitles);
        }
    }
}
