namespace Forum.App.UserInterface.Contracts
{
    public interface IView
    {
        ILabel[] Labels { get; }

        ILabel[] Buttons { get; }
    }
}