using Employees.Services;

namespace Employees.App.Commands
{
    class AddEmployeeCommand : ICommand
    {
        private EmployeeService employeeService;

        public AddEmployeeCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            string firstName = arguments[0];
            string lastName = arguments[1];
            decimal salary = decimal.Parse(arguments[2]);

            employeeService.Add(firstName, lastName, salary);

            return $"{firstName} {lastName} added successfuly";
        }
    }
}
