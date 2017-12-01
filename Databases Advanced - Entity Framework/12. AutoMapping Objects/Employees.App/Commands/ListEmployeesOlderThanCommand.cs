using System;
using Employees.Services;
using System.Linq;

namespace Employees.App.Commands
{
    class ListEmployeesOlderThanCommand : ICommand
    {
        private EmployeeService employeeService;

        public ListEmployeesOlderThanCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            int age = int.Parse(arguments[0]);

            var employeeManagerDtos = employeeService.OlderThan(age);

            return String.Join(Environment.NewLine, employeeManagerDtos.Select(em => $"{em.FirstName} {em.LastName} - ${em.Salary:f2} - Manager: {(em.ManagerLastName == null ? "[no manager]" : em.ManagerLastName)}"));
        }
    }
}
