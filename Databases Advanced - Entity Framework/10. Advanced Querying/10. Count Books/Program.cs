using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _10._Count_Books
{
    class Program
    {
        public static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());

            using(var context = new BookShopContext())
            {
                Console.WriteLine(CountBooks(context, length));
            }
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
        }
    }
}
