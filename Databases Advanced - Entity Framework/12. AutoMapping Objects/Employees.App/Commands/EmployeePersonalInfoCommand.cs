using System;
using Employees.Services;
using System.Linq;

namespace Employees.App.Commands
{
    class EmployeePersonalInfoCommand : ICommand
    {
        private EmployeeService employeeService;

        public EmployeePersonalInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            int id = int.Parse(arguments[0]);

            var employee = employeeService.PersonalInfo(id);

            string birthDate = employee.BithdDate != null ? employee.BithdDate.Value.ToString() : "[no data]";
            string address = employee.Address != null ? employee.Address : "[no data]";

            return $"ID: {id} - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}" + Environment.NewLine + $"Birthday: {birthDate}" + Environment.NewLine + $"Address: {address}";
        }
    }
}
