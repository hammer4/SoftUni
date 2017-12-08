namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Utilities;

    // • Logout
    public class LogoutCommand
    {
        public string Execute(string[] commandArgs)
        {
            Check.CheckLength(0, commandArgs);

            string username = AuthenticationManager.GetCurrentUser()?.Username;

            AuthenticationManager.Logout();

            return $"User {username} successfully logged out!";
        }
    }
}
