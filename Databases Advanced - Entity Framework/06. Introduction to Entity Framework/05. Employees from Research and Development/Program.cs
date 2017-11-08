using System;
using System.Linq;

using P02_DatabaseFirst.Data;

namespace _5._Employees_from
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new SoftUniContext())
            {
                dbContext.Employees
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary).
                    ThenByDescending(e => e.FirstName)
                    .Select(e => new { e.FirstName, e.LastName, DepartmentName = e.Department.Name, e.Salary })
                    .ToList()
                    .ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}"));
            }
        }
    }
}
