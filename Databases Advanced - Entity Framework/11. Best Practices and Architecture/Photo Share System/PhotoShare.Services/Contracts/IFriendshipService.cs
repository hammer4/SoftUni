using System.Collections.Generic;

namespace PhotoShare.Services.Contracts
{
    public interface IFriendshipService
    {
        void AddFriend(string userUsername, string friendUsername);
        void AcceptFriend(string userUsername, string friendUsername);
        List<string> ListFriends(string username);
    }
}
