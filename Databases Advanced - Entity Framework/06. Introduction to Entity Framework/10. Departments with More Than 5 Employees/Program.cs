using System;
using System.Linq;

using P02_DatabaseFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace _10._Departments_with
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(Console.BufferWidth, 1000);

            using (var dbContext = new SoftUniContext())
            {
                dbContext.Departments
                    .Include(d => d.Employees)
                    .Include(d => d.Manager)
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .ToList()
                    .ForEach(d => Console.WriteLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}{Environment.NewLine}{String.Join(Environment.NewLine, d.Employees.OrderBy(e=> e.FirstName).ThenBy(e => e.LastName).Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle}").ToList())}{Environment.NewLine}{new string('-', 10)}"));
            }
        }
    }
}
