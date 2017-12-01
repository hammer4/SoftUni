using System;

namespace Employees.App.Commands
{
    class ExitCommand : ICommand
    {
        public string Execute(params string[] arguments)
        {
            Environment.Exit(0);
            return String.Empty;
        }
    }
}
