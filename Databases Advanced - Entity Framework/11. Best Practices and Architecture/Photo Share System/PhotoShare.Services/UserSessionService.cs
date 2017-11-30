using PhotoShare.Models;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Services
{
    public class UserSessionService : IUserSessionService
    {
        public User User { get; set; }

        public bool IsLoggedIn() => this.User != null;
    }
}
