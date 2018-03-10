namespace Forum.App.Controllers.Contracts
{
    using Forum.App.UserInterface.Contracts;

    public interface IController
    {
        MenuState ExecuteCommand(int index);

        IView GetView(string userName);
    }
}
