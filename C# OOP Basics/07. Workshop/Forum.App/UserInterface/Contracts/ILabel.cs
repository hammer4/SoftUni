namespace Forum.App.UserInterface.Contracts
{
    using Forum.App;

    public interface ILabel : IPositionable
    {
        string Text { get; }

        bool IsHidden { get; }
    }
}