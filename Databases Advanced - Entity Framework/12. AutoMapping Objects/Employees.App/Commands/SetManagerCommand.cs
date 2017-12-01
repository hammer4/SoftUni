using System;
using Employees.Services;
using System.Linq;

namespace Employees.App.Commands
{
    class SetManagerCommand : ICommand
    {
        private EmployeeService employeeService;

        public SetManagerCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            int employeeId = int.Parse(arguments[0]);
            int managerId = int.Parse(arguments[1]);

            var employeeArr = employeeService.SetManager(employeeId, managerId);

            return $"{employeeArr[1].FirstName} {employeeArr[1].LastName} is set as manager to {employeeArr[0].FirstName} {employeeArr[0].LastName}";
        }
    }
}
