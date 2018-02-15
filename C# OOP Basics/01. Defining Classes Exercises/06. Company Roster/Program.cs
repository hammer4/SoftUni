using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for(int i=0; i<count; i++)
        {
            var tokens = Console.ReadLine().Split();

            if(tokens.Length == 4)
            {
                employees.Add(new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2], tokens[3]));
            }
            else if(tokens.Length == 5)
            {
                if (tokens[4].Contains("@"))
                {
                    employees.Add(new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2], tokens[3], tokens[4]));
                }
                else
                {
                    employees.Add(new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2], tokens[3], int.Parse(tokens[4])));
                }
            }
            else if(tokens.Length == 6)
            {
                employees.Add(new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2], tokens[3], tokens[4], int.Parse(tokens[5])));
            }
        }

        string bestPaidDept = employees
            .GroupBy(e => e.Department)
            .Select(g => new { Department = g.Key, AvgSalary = g.Average(e => e.Salary) })
            .OrderByDescending(o => o.AvgSalary)
            .First()
            .Department;

        Console.WriteLine($"Highest Average Salary: {bestPaidDept}");

        employees
            .Where(e => e.Department == bestPaidDept)
            .OrderByDescending(e => e.Salary)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}