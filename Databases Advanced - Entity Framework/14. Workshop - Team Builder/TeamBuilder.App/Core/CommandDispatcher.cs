namespace TeamBuilder.App.Core
{
    using System;
    using System.Linq;
    using TeamBuilder.App.Core.Commands;

    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty;

            var inputArgs = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputArgs.Length > 0 ? inputArgs[0] : string.Empty;
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            switch (command.ToLower())
            {
                case "registeruser": result = new RegisterUserCommand().Execute(commandArgs);
                    break;
                case "login": result = new LoginCommand().Execute(commandArgs);
                    break;
                case "logout": result = new LogoutCommand().Execute(commandArgs);
                    break;
                case "deleteuser": result = new DeleteUserCommand().Execute(commandArgs);
                    break;
                case "createevent": result = new CreateEventCommand().Execute(commandArgs);
                    break;
                case "createteam": result = new CreateTeamCommand().Execute(commandArgs);
                    break;
                case "invitetoteam": result = new InviteToTeamCommand().Execute(commandArgs);
                    break;
                case "acceptinvite": result = new AcceptInviteCommand().Execute(commandArgs);
                    break;
                case "declineinvite": result = new DeclineInviteCommand().Execute(commandArgs);
                    break;
                case "kickmember": result = new KickMemberCommand().Execute(commandArgs);
                    break;
                case "disband": result = new DisbandCommand().Execute(commandArgs);
                    break;
                case "addteamto": result = new AddTeamToCommand().Execute(commandArgs);
                    break;
                case "showevent": result = new ShowEventCommand().Execute(commandArgs);
                    break;
                case "showteam": result = new ShowTeamCommand().Execute(commandArgs);
                    break;


                case "exit":
                    var exit = new ExitCommand().Execute(commandArgs);
                    break;
                default: throw new NotSupportedException($"Command {command} not supported!");

            }

            return result;
        }
    }
}
