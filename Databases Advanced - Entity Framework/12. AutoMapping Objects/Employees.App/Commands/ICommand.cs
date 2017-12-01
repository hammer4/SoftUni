namespace Employees.App.Commands
{
    public interface ICommand
    {
        string Execute(params string[] arguments);
    }
}
