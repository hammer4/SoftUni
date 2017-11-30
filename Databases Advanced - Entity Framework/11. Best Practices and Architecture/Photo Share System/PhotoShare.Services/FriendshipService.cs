using PhotoShare.Services.Contracts;
using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PhotoShare.Services
{
    public class FriendshipService : IFriendshipService
    {
        private PhotoShareContext context;
        private IUserService userService;

        public FriendshipService(PhotoShareContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public void AddFriend(string userUsername, string friendUsername)
        {
            User user = userService.ByUsername(userUsername);

            if(user == null)
            {
                throw new ArgumentException($"{userUsername} not found!");
            }

            User friend = userService.ByUsername(friendUsername);

            if (friend == null)
            {
                throw new ArgumentException($"{friendUsername} not found!");
            }

            var invitationSent = context.Friendships.Any(fr => fr.User == user && fr.Friend == friend);

            if (invitationSent)
            {
                throw new InvalidOperationException($"{user.Username} has already added {friend.Username} as a friend");
            }

            var friendshipExists = context.Friendships.Any(fr => fr.User == user && fr.Friend == friend) &&
                context.Friendships.Any(fr => fr.User == friend && fr.Friend == user);

            if (friendshipExists)
            {
                throw new InvalidOperationException($"{friend.Username} is already a friend to {user.Username}");
            }

            context.Friendships.Add(new Friendship { User = user, Friend = friend });

            context.SaveChanges();
        }

        public void AcceptFriend(string userUsername, string friendUsername)
        {
            User user = userService.ByUsername(userUsername);

            if (user == null)
            {
                throw new ArgumentException($"{userUsername} not found!");
            }

            User friend = userService.ByUsername(friendUsername);

            if (friend == null)
            {
                throw new ArgumentException($"{friendUsername} not found!");
            }

            var invitationSent = context.Friendships.Any(fr => fr.User == friend && fr.Friend == user);

            if (!invitationSent)
            {
                throw new InvalidOperationException($"{friend.Username} has not added {user.Username} as a friend");
            }

            var friendshipExists = context.Friendships.Any(fr => fr.User == user && fr.Friend == friend) &&
                context.Friendships.Any(fr => fr.User == friend && fr.Friend == user);

            if (friendshipExists)
            {
                throw new InvalidOperationException($"{friend.Username} is already a friend to {user.Username}");
            }

            context.Friendships.Add(new Friendship { User = user, Friend = friend });

            context.SaveChanges();
        }

        public List<string> ListFriends(string username)
        {
            var user = userService.ByUsername(username);

            if(user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var addedFriends = context.Friendships
                .Where(f => f.User == user)
                .Select(f => f.Friend.Username)
                .ToList();

            var acceptedFriends = context.Friendships
                .Where(f => f.Friend == user)
                .Select(f => f.User.Username)
                .ToList();

            return addedFriends.Intersect(acceptedFriends).ToList();
        }
    }
}
