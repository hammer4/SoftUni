using System;
using System.Linq;

using P02_DatabaseFirst.Data;

namespace _04._Employees_with
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new SoftUniContext())
            {
                dbContext.Employees
                    .Where(e => e.Salary > 50000)
                    .Select(e => new { e.FirstName })
                    .OrderBy(e => e.FirstName)
                    .ToList()
                    .ForEach(e => Console.WriteLine(e.FirstName));
            }
        }
    }
}
