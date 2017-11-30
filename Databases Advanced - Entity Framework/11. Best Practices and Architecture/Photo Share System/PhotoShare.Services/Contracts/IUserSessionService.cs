using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface IUserSessionService
    {
        User User { get; set; }

        bool IsLoggedIn();
    }
}
