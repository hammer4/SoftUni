using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _11._Total_Book_Copies
{
    class Program
    {
        public static void Main(string[] args)
        {
            using(var context = new BookShopContext())
            {
                Console.WriteLine(CountCopiesByAuthor(context));
            }
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copiesByAuthor = context.Authors
                .Select(a => new
                    {
                        Name = $"{a.FirstName} {a.LastName}",
                        Copies = a.Books.Select(b => b.Copies).Sum()
                    })
                .OrderByDescending(a => a.Copies)
                .ToList();

            return String.Join(Environment.NewLine, copiesByAuthor.Select(c => $"{c.Name} - {c.Copies}"));
        }
    }
}
