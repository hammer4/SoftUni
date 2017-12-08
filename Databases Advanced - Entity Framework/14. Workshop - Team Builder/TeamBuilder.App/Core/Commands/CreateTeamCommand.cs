namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    //•	CreateTeam <name> <acronym> <description>
    public class CreateTeamCommand
    {
        public string Execute(string[] commandArgs)
        {
            int argsCount = commandArgs.Length;
            if (argsCount < 2 || argsCount > 3)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidArgumentsCount);
            }

            AuthenticationManager.Authorize();

            var user = AuthenticationManager.GetCurrentUser();

            string teamName = commandArgs[0];
            CheckTeamName(teamName);

            string acronym = commandArgs[1];
            CheckAcronym(acronym);

            string description = null;
            if (argsCount == 3)
            {
                description = commandArgs[2];
                CheckDescription(description);
            }

            AddTeamToDb(user.Id, teamName, acronym, description);

            return $"Team {teamName} successfully created!";
        }

        private void AddTeamToDb(int id, string teamName, string acronym, string description)
        {
            using (var context = new TeamBuilderContext())
            {
                var team = new Team
                {
                    Name = teamName,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = id
                };

                context.Teams.Add(team);
                context.SaveChanges();
            }
        }

        private void CheckDescription(string description)
        {
            if (description.Length > 32)
            {
                throw new ArgumentException("Team description should be up to 32 characters long!");
            }
        }

        private void CheckAcronym(string acronym)
        {
            if (acronym.Length != 3)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidAcronym, acronym));
            }
        }

        private void CheckTeamName(string teamName)
        {
            if (teamName.Length > 25)
            {
                throw new ArgumentException("Team name should be up to 25 characters long!");
            }

            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamExists, teamName));
            }
        }
    }
}
