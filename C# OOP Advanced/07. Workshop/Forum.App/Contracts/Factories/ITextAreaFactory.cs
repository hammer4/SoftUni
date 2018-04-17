namespace Forum.App.Contracts
{
	public interface ITextAreaFactory
	{
		ITextInputArea CreateTextArea(IForumReader reader, int x, int y, bool isPost = true);
	}
}
