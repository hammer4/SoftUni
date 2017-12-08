namespace TeamBuilder.App.Core.Commands
{
    using System.Linq;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;

    // • DeleteUser
    public class DeleteUserCommand
    {
        public string Execute(string[] commandParams)
        {
            Check.CheckLength(0, commandParams);
            AuthenticationManager.Authorize();

            var user = AuthenticationManager.GetCurrentUser();
            var username = user.Username;

            using (var context = new TeamBuilderContext())
            {
                context.Users.FirstOrDefault(u => u.Id == user.Id).IsDeleted = true;
                context.SaveChanges();
            }

            AuthenticationManager.Logout();

            return $"User {username} was deleted successfully!"; 
        }
    }
}