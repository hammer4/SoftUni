using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int employeesCount = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for(int i = 1; i <= employeesCount; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            string name = tokens[0];
            decimal salary = decimal.Parse(tokens[1]);
            string position = tokens[2];
            string department = tokens[3];
            int age;

            if(tokens.Length == 5)
            {
                int.TryParse(tokens[4], out age);

                if(age > 0)
                {
                    employees.Add(new Employee(name, salary, position, department, age));
                }
                else
                {
                    employees.Add(new Employee(name, salary, position, department, tokens[4]));
                }
            }
            else if (tokens.Length == 6)
            {
                employees.Add(new Employee(name, salary, position, department, tokens[4], int.Parse(tokens[5])));
            }
            else {
                employees.Add(new Employee(name, salary, position, department));
            }
        }

        var bestPaidDept = employees.GroupBy(e => e.Department).Select(g => new { Department = g.Key, Avg = g.Average(e => e.Salary) }).ToList().OrderByDescending(d => d.Avg).ToList()[0].Department;

        Console.WriteLine($"Highest Average Salary: {bestPaidDept}");
        employees.Where(e => e.Department == bestPaidDept).OrderByDescending(e => e.Salary).ToList().ForEach(e => Console.WriteLine(e));
    }
}
