using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using PhotoShare.Data;
using System.Linq;
using System;

namespace PhotoShare.Services
{
    public class UserService : IUserService
    {
        private readonly PhotoShareContext context;
        private IUserSessionService userSessionService;
        private ITownService townService;

        public UserService(PhotoShareContext context, IUserSessionService userSessionService, ITownService townService)
        {
            this.context = context;
            this.userSessionService = userSessionService;
            this.townService = townService;
        }

        public User ById(int id)
        {
            return this.context.Users
                .SingleOrDefault(u => u.Id == id);
        }

        public User ByUsername(string username)
        {
            return this.context.Users
                .SingleOrDefault(u => u.Username == username);
        }

        public User ByUsernameAndPassword(string username, string password)
        {
            return this.context.Users
                .SingleOrDefault(u => u.Username == username && u.Password == password);
        }

        public User Create(string username, string password, string confirmPassword, string email)
        {
            if(password != confirmPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            var user = this.ByUsername(username);

            if (user != null)
            {
                throw new InvalidOperationException($"Username {username} is already taken!");
            }

            user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                RegisteredOn = DateTime.Now
            };

            context.Users.Add(user);

            context.SaveChanges();

            return user;
        }

        public User Login(string username, string password)
        {
            var user = this.ByUsernameAndPassword(username, password);

            if(user == null)
            {
                throw new ArgumentException("Invalid username or password!");
            }

            this.userSessionService.User = user;

            user.LastTimeLoggedIn = DateTime.Now;

            context.SaveChanges();

            return user;
        }

        public User ModifyUser(string username, string property, string newValue)
        {
            var user = this.ByUsername(this.userSessionService.User.Username);

            if(user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            switch (property)
            {
                case "Password":
                    if(!(newValue.Any(ch => Char.IsLower(ch)) && newValue.Any(ch => Char.IsDigit(ch))))
                    {
                        throw new ArgumentException($"Value {newValue} not valid. Invalid Password");
                    }

                    user.Password = newValue;
                    break;
                case "BornTown":
                    var town = this.townService.ByName(newValue);
                    if(town == null)
                    {
                        throw new ArgumentException($"Value {newValue} not valid. Town {newValue} not found!");
                    }

                    user.BornTown = town;
                    break;
                case "CurrentTown":
                    town = this.townService.ByName(newValue);
                    if (town == null)
                    {
                        throw new ArgumentException($"Value {newValue} not valid. Town {newValue} not found!");
                    }

                    user.CurrentTown = town;
                    break;
            }

            context.SaveChanges();

            return user;
        }

        public string Logout()
        {
            string username = this.userSessionService.User.Username;
            this.userSessionService.User = null;

            return username;
        }
   
        public void Delete(string username)
        {
            var user = this.ByUsername(username);

            if(user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if ((bool)user.IsDeleted)
            {
                throw new InvalidOperationException($"User {user.Username} is already deleted!");
            }

            user.IsDeleted = true;

            context.SaveChanges();
        }
    }
}
