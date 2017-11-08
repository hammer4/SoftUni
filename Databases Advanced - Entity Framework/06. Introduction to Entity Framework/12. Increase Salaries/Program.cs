using System;
using System.Linq;

using P02_DatabaseFirst.Data;

namespace _12._Increase_Salaries
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new SoftUniContext())
            {
                dbContext.Employees
                    .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                        .Contains(e.Department.Name))
                    .ToList()
                    .ForEach(e => e.Salary *= 1.12m);

                dbContext.SaveChanges();

                dbContext.Employees
                    .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                        .Contains(e.Department.Name))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                    .ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})"));
            }
        }
    }
}
