using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _05._Book_Titles_by_Category
{
    class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            using(var context = new BookShopContext())
            {
                Console.WriteLine(GetBooksByCategory(context, input));
            }
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower()).ToArray();

            var booksTitles = context.Books
                .Where(b => b.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksTitles);
        }
    }
}
