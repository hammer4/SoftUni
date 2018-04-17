namespace Forum.App.Contracts
{
    public interface IReplyViewModel
    {
		string Author { get; }

		string[] Content { get; }
    }
}
