using System;
using Employees.Data;
using Employees.Models;
using Employees.ModelsDto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Employees.Services
{
    public class EmployeeService
    {
        private readonly EmployeesContext context;

        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }

        public void Add(string firstName, string lastName, decimal salary)
        {
            var employeeDto = new EmployeeDto { FirstName = firstName, LastName = lastName, Salary = salary };
            var employee = Mapper.Map<Employee>(employeeDto);

            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public Employee SetBirthday(int id, DateTime date)
        {
            var employee = context.Employees.Find(id);

            employee.BirthDate = date;

            context.SaveChanges();

            return employee;
        }

        public Employee SetAddress(int id, string address)
        {
            var employee = context.Employees.Find(id);

            employee.Address = address;

            context.SaveChanges();

            return employee;
        }

        public EmployeeDto Info(int id)
        {
            return ById(id);
        }

        public PersonaInfoDto PersonalInfo(int id)
        {
            var employee = context.Employees.Find(id);

            if (employee == null)
            {
                throw new Exception("Invalid Employee Id");
            }

            var personaInfoDto = Mapper.Map<PersonaInfoDto>(employee);

            return personaInfoDto;
        }

        public EmployeeDto[] SetManager(int employeeId, int managerId)
        {
            var employee = context.Employees.Find(employeeId);
            var manager = context.Employees.Find(managerId);

            employee.Manager = manager;

            context.SaveChanges();

            var employeeDto = Mapper.Map<EmployeeDto>(employee);
            var employeeDtoMAnager = Mapper.Map<EmployeeDto>(manager); 

            return new[] { employeeDto, employeeDtoMAnager };
        }

        public ManagerDto ManagerInfo (int id)
        {
            var manager = context.Employees
                .Include(e => e.ManagedEmployees)
                .SingleOrDefault(e => e.Id == id);

            var managerDto = Mapper.Map<ManagerDto>(manager);

            return managerDto;
        }

        public EmployeeManager[] OlderThan(int age)
        {
            var employees = context.Employees
                .Include(e => e.Manager)
                .Where(e => e.BirthDate != null && e.BirthDate.Value.Year + age < DateTime.Now.Year)
                .OrderByDescending(e => e.Salary)
                .ProjectTo<EmployeeManager>()
                .ToArray();

            return employees;
        }

        private EmployeeDto ById(int id)
        {
            var employee = context.Employees.Find(id);

            if(employee == null)
            {
                throw new Exception("Invalid Employee Id");
            }

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }
    }
}
