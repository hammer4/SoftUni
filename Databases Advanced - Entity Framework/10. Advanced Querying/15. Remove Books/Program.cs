using System;
using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace _15._Remove_Books
{
    class Program
    {
        public static void Main(string[] args)
        {
            using(var context = new BookShopContext())
            {
                Console.WriteLine($"{RemoveBooks(context)} books were deleted");
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksForDelete = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(booksForDelete);
            context.SaveChanges();

            //return context.SaveChanges(); not working in judge

            return booksForDelete.Count;
        }
    }
}
