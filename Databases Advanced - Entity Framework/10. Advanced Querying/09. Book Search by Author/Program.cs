using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _09._Book_Search_by_Author
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            using(var context = new BookShopContext())
            {
                Console.WriteLine(GetBooksByAuthor(context, input));
            }
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksWithAuthor = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title, b.Author.FirstName, b.Author.LastName })
                .ToList();

            return String.Join(Environment.NewLine, booksWithAuthor.Select(b => $"{b.Title} ({b.FirstName} {b.LastName})"));
        }
    }
}
