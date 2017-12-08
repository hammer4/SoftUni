namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    //•	AddTeamTo <eventName> <teamName>

    public class AddTeamToCommand
    {
        public string Execute(string[] commandArgs)
        {
            Check.CheckLength(2, commandArgs);
            AuthenticationManager.Authorize();

            var user = AuthenticationManager.GetCurrentUser();
            string eventName = commandArgs[0];
            string teamName = commandArgs[1];

            if (!CommandHelper.IsUserCreatorOfEvent(eventName, user))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(String.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(String.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            Event eventa = null;
            Team team = null;

            using(var context = new TeamBuilderContext())
            {
                eventa = context.Events
                    .Where(e => e.Name == eventName)
                    .OrderBy(e => e.StartDate)
                    .Last();

                team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                if(context.EventTeams.Any(et => et.Team == team && et.Event == eventa))
                {
                    throw new InvalidOperationException("Cannot add same team twice!");
                }

                context.EventTeams.Add(new EventTeam { Event = eventa, Team = team });
                context.SaveChanges();
            }

            return $"Team {teamName} added for {eventName}!";
        }
    }
}
