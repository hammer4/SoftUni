using System;
using System.Linq;

using P02_DatabaseFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace _14._Delete_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new SoftUniContext())
            {
                var project = dbContext.Projects.First(p => p.ProjectId == 2);

                dbContext.EmployeesProjects.ToList().ForEach(ep => dbContext.EmployeesProjects.Remove(ep));
                dbContext.Projects.Remove(project);

                dbContext.SaveChanges();

                dbContext.Projects.Take(10).Select(p => p.Name).ToList().ForEach(p => Console.WriteLine(p));
            }
        }
    }
}
