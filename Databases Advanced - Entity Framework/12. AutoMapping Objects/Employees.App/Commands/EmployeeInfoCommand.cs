using System;
using Employees.Services;
using System.Linq;

namespace Employees.App.Commands
{
    class EmployeeInfoCommand : ICommand
    {
        private EmployeeService employeeService;

        public EmployeeInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            int id = int.Parse(arguments[0]);

            var employee = employeeService.Info(id);

            return $"ID: {employee.Id} - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}";
        }
    }
}
