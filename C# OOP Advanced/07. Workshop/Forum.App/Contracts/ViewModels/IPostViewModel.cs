namespace Forum.App.Contracts
{
    public interface IPostViewModel
    {
		string Title { get; }

		string Author { get; }

		string[] Content { get; }

		IReplyViewModel[] Replies { get; }
    }
}
