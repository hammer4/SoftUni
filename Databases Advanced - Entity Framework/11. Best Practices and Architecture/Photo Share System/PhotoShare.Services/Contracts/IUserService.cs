using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface IUserService
    {
        User ById(int id);

        User ByUsername(string username);

        User ByUsernameAndPassword(string username, string password);

        User Create(string username, string password, string confirmPassword, string email);

        User ModifyUser(string username, string property, string newValue);

        void Delete(string username);

        User Login(string username, string password);

        string Logout();
    }
}
