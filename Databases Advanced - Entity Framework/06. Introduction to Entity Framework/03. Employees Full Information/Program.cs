using System;
using System.Linq;

using P02_DatabaseFirst.Data;

namespace _03._Employees_Full
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new SoftUniContext())
            {
                dbContext.Employees
                    .OrderBy(e => e.EmployeeId)
                    .Select(e => new { e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary })
                    .ToList()
                    .ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}"));
            }
        }
    }
}
