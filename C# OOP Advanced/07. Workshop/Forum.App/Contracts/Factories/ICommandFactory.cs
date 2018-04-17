namespace Forum.App.Contracts
{

    public interface ICommandFactory
    {
		ICommand CreateCommand(string commandName);
    }
}
