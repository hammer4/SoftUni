namespace Forum.App.Controllers.Contracts
{
    public interface IUserRestrictedController
    {
        bool LoggedInUser { get; }

        void UserLogIn();

        void UserLogOut();
    }
}
