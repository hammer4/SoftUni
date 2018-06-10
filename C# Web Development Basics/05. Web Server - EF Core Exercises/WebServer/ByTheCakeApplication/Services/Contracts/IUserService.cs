namespace WebServer.ByTheCakeApplication.Services.Contracts
{
    using ViewModels.Account;

    public interface IUserService
    {
        bool Create(string username, string password);

        bool Find(string username, string password);

        ProfileViewModel Profile(string username);

        int? GetUserId(string username);
    }
}
