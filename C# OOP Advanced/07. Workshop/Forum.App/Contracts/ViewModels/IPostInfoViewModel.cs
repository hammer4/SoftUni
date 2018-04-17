namespace Forum.App.Contracts
{
    public interface IPostInfoViewModel
    {
		int Id { get; }

		string Title { get; }

		int ReplyCount { get; }
    }
}
