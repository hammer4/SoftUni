using System;
using System.Linq;

using P02_DatabaseFirst.Data;

namespace _11._Find_Latest_10
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new SoftUniContext())
            {
                dbContext.Projects.
                    OrderByDescending(p => p.StartDate).
                    Take(10).
                    Select(p => new { p.Name, p.Description, p.StartDate })
                    .OrderBy(p => p.Name)
                    .ToList()
                    .ForEach(p => Console.WriteLine($"{p.Name}{Environment.NewLine}{p.Description}{Environment.NewLine}{p.StartDate}"));
            }
        }
    }
}
