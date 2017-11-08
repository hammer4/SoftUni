using System;
using System.Linq;

using P02_DatabaseFirst.Data;

namespace _09._Employee_147
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new SoftUniContext())
            {
                var employee = dbContext.Employees.
                    Where(e => e.EmployeeId == 147)
                    .Select(e => new {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                        Projects = e.EmployeesProjects
                            .Select(ep => ep.Project.Name)
                            .OrderBy(p => p)
                            .ToList() })
                    .First();

                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}{Environment.NewLine}{String.Join(Environment.NewLine, employee.Projects)}");
            }
        }
    }
}
