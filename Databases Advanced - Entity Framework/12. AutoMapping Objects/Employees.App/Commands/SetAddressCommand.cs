using System;
using Employees.Services;
using System.Linq;

namespace Employees.App.Commands
{
    class SetAddressCommand : ICommand
    {
        private EmployeeService employeeService;

        public SetAddressCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            int id = int.Parse(arguments[0]);
            string address = String.Join(" ", arguments.Skip(1));

            var employee = employeeService.SetAddress(id, address);

            return $"{employee.FirstName} {employee.LastName}'s address is set to {String.Join(" ", arguments.Skip(1))}";
        }
    }
}
