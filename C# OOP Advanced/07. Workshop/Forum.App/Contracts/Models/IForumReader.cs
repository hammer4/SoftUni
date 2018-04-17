namespace Forum.App.Contracts
{
    public interface IForumReader
    {
		string ReadLine();

		string ReadLine(int left, int top);

		void HideCursor();

		void ShowCursor();
    }
}
