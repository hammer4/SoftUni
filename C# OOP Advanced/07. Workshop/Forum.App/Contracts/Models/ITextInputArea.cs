namespace Forum.App.Contracts
{
    public interface ITextInputArea
    {
		string Text { get; }

		void Write();

		void Render();
    }
}
