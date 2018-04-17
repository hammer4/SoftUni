namespace Forum.App.Contracts
{
    public interface ICategoryInfoViewModel
    {
		int Id { get; }

		string Name { get; }

		int PostCount { get; }
	}
}
