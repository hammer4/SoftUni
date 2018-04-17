namespace Forum.App.Contracts
{ 
    public interface ICommand
    {
		IMenu Execute(params string[] args);
    }
}
