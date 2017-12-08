namespace TeamBuilder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Username { get; set; }

        [MinLength(6)]
        // [RegularExpression("(?=.*[A-Z])(?=.*[0-9]).*")]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Team> CreatedTeams { get; set; } = new List<Team>();

        public ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();

        public ICollection<Event> CreatedEvents { get; set; } = new List<Event>();

        public ICollection<Invitation> ReceivedInvitations { get; set; } = new List<Invitation>();
    }
}
