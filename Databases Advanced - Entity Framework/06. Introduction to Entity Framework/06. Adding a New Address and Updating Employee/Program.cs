using System;
using System.Linq;

using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;

namespace _06._Adding_a_New
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new SoftUniContext())
            {
                var address = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                dbContext.Employees
                    .Single(e => e.LastName == "Nakov")
                    .Address = address;

                dbContext.SaveChanges();

                dbContext.Employees
                    .OrderByDescending(e => e.Address.AddressId)
                    .Take(10)
                    .Select(e => e.Address.AddressText)
                    .ToList()
                    .ForEach(at => Console.WriteLine(at));
            }
        }
    }
}
