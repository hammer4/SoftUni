namespace Forum.App.Contracts
{
    public interface ITextAreaMenu : IMenu
    {
		ITextInputArea TextArea { get; }
    }
}
