using System;
using Employees.Services;
using System.Linq;

namespace Employees.App.Commands
{
    class ManagerInfoCommand : ICommand
    {
        private EmployeeService employeeService;

        public ManagerInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            int id = int.Parse(arguments[0]);

            var manager = employeeService.ManagerInfo(id);

            return $"{manager.FirstName} {manager.LastName} | Employees: {manager.EmployeesCount}" +
            $"{(manager.EmployeesCount == 0 ? null : Environment.NewLine )}" +
                String.Join(Environment.NewLine, manager.EmployeeDtos.Select(dto => $"    - {dto.FirstName} {dto.LastName} - ${dto.Salary:f2}"));
        }
    }
}
