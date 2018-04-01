public interface ICommandInterpreter
{
    IExecutable InterpretCommand(string commandName, string[] data);
}
