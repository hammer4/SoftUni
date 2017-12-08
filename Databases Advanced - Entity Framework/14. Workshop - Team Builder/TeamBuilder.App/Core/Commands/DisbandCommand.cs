namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;

    //•	Disband <teamName>

    public class DisbandCommand
    {
        public string Execute(string[] commandArgs)
        {
            Check.CheckLength(1, commandArgs);
            AuthenticationManager.Authorize();

            var user = AuthenticationManager.GetCurrentUser();

            var teamName = commandArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(String.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if(!CommandHelper.IsUserCreatorOfTeam(teamName, user))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            using(var context = new TeamBuilderContext())
            {
                var team = context.Teams.SingleOrDefault(t => t.Name == teamName);

                var eventTeams = context.EventTeams.Where(et => et.Team == team);
                var userTeams = context.UserTeams.Where(ut => ut.Team == team);
                var invitations = context.Invitations.Where(i => i.Team == team);

                context.EventTeams.RemoveRange(eventTeams);
                context.UserTeams.RemoveRange(userTeams);
                context.Invitations.RemoveRange(invitations);

                context.Teams.Remove(team);

                context.SaveChanges();
            }

            return $"{teamName} has disbanded!";
        }
    }
}