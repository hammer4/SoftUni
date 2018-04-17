namespace Forum.App.Contracts
{
    public interface IMainController
    {
		void MarkOption();

		void UnmarkOption();

		void NextOption();

		void PreviousOption();

		void Back();

		void Execute();
    }
}
