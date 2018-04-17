namespace Forum.App.Contracts
{
    public interface IMenuFactory
    {
		IMenu CreateMenu(string menuName);
    }
}
