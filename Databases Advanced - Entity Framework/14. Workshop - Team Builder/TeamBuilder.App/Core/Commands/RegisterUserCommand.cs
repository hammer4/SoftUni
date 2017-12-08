namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    // •RegisterUser <username> <password> <repeat-password> <firstName> <lastName> <age> <gender>
    public class RegisterUserCommand
    {
        public string Execute(string[] commandArgs)
        {
            Check.CheckLength(7, commandArgs);

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            string username = commandArgs[0];

            if (username.Length < Constants.MinUsernameLength || username.Length > Constants.MaxUsernameLength)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid, username));
            }

            string pass = commandArgs[1];

            if (pass.Length < Constants.MinPasswordLength ||
                pass.Length > Constants.MaxPasswordLength ||
                !pass.Any(char.IsUpper) ||
                !pass.Any(char.IsDigit))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, pass));
            }

            string rptPass = commandArgs[2];

            if (rptPass != pass)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.PasswordDoesNotMatch);
            }

            string firstName = commandArgs[3];

            if (firstName.Length > Constants.MaxFirstNameLength)
            {
                throw new ArgumentException(Constants.ErrorMessages.FirstNameNotValid);
            }

            string lastName = commandArgs[4];

            if (lastName.Length > Constants.MaxLastNameLength)
            {
                throw new ArgumentException(Constants.ErrorMessages.LastNameNotValid);
            }

            int age;
            bool isNumber = int.TryParse(commandArgs[5], out age);
            if (!isNumber || age <= 0)
            {
                throw new ArgumentException(Constants.ErrorMessages.AgeNotValid);
            }

            Gender gender;
            bool isGenderValid = Enum.TryParse(commandArgs[6], out gender);

            if (!isGenderValid)
            {
                throw new ArgumentException(Constants.ErrorMessages.GenderNotValid);
            }

            if (CommandHelper.IsUserExisting(username))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.UsernameIsTaken, username));
            }

            this.RegisterUser(username, pass, firstName, lastName, age, gender); 

            return $"User {username} was registered succesfully";
        }

        private void RegisterUser(string username, string pass, string firstName, string lastName, int age, Gender gender)
        {
            var user = new User
            {
                Username = username,
                Password = pass,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender
            };

            using (var context = new TeamBuilderContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
