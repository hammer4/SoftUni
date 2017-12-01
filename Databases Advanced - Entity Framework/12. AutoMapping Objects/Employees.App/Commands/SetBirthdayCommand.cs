using System;
using Employees.Services;

namespace Employees.App.Commands
{
    class SetBirthdayCommand : ICommand
    {
        private EmployeeService employeeService;

        public SetBirthdayCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            int id = int.Parse(arguments[0]);
            DateTime date = DateTime.ParseExact(arguments[1], "dd-MM-yyyy", null);

            var employee = employeeService.SetBirthday(id, date);

            return $"{employee.FirstName} {employee.LastName}'s birth date is set to {arguments[1]}";
        }
    }
}
