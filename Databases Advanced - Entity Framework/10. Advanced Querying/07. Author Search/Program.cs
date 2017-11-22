using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _07._Author_Search
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            using(var context = new BookShopContext())
            {
                Console.WriteLine(GetAuthorNamesEndingIn(context, input));
            }
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
                .ToList();

            return String.Join(Environment.NewLine, authorNames);
        }
    }
}
