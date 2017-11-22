using System;

using BookShop.Data;
using BookShop.Models;
using System.Linq;

namespace BookShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string ageRestriction = Console.ReadLine();

            using(var context = new BookShopContext())
            {
                Console.WriteLine(GetBooksByAgeRestriction(context, ageRestriction));
            }
        }

        static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            int ageRestriction = AgeRestriction.Minor.ToString().ToLower().Equals(command.ToLower()) ? 0 :
                AgeRestriction.Teen.ToString().ToLower().Equals(command.ToLower()) ? 1 :
                AgeRestriction.Adult.ToString().ToLower().Equals(command.ToLower()) ? 2 : 3;

            var booksTitles = context.Books
                .Where(b => (int)b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, booksTitles);
        }
    }
}
