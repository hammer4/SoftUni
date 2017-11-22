using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _13._Most_Recent_Books
{
    class Program
    {
        public static void Main(string[] args)
        {
            using(var context = new BookShopContext())
            {
                Console.WriteLine(GetMostRecentBooks(context));
            }
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriesWithBooks = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .Select(cb => cb.Book)
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                })
                .ToList();

            return String.Join(Environment.NewLine, 
                categoriesWithBooks
                    .Select(c => $"--{c.Name}{Environment.NewLine}{String.Join(Environment.NewLine, c.Books.Select(b => $"{b.Title} ({b.ReleaseDate.Value.Year})"))}"));
        }
    }
}
