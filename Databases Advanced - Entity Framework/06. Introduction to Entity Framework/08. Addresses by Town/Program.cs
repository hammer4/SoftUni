using System;
using System.Linq;

using P02_DatabaseFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace _08._Addresses_by_Town
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                dbContext.Addresses
                    .GroupBy(a => new {
                            a.AddressId,
                            a.AddressText,
                            a.Town.Name
                        }, 
                        (key, group) => new {
                            AddressText = key.AddressText,
                            Town = key.Name,
                            Count = group.Sum(a => a.Employees.Count)
                        })
                    .OrderByDescending(o => o.Count)
                    .ThenBy(o => o.Town)
                    .ThenBy(o => o.AddressText)
                    .Take(10)
                    .ToList()
                    .ForEach(o => Console.WriteLine($"{o.AddressText}, {o.Town} - {o.Count} employees"));
            }
        }
    }
}
