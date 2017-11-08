using System;
using System.Linq;

using P02_DatabaseFirst.Data;

namespace _15._Remove_Towns
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new SoftUniContext())
            {
                string townName = Console.ReadLine();

                dbContext.Employees
                    .Where(e => e.Address.Town.Name == townName)
                    .ToList()
                    .ForEach(e => e.AddressId = null);

                int addressesCount = dbContext.Addresses
                    .Where(a => a.Town.Name == townName)
                    .Count();

                dbContext.Addresses
                    .Where(a => a.Town.Name == townName)
                    .ToList()
                    .ForEach(a => dbContext.Addresses.Remove(a));

                dbContext.Towns
                    .Remove(dbContext.Towns
                        .SingleOrDefault(t => t.Name == townName));

                dbContext.SaveChanges();

                Console.WriteLine($"{addressesCount} {(addressesCount == 1 ? "address" : "addresses")} in {townName} {(addressesCount == 1 ? "was" : "were")} deleted");
            }
        }
    }
}
