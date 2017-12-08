namespace TeamBuilder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [MinLength(3)]
        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<UserTeam> Members { get; set; } = new List<UserTeam>();

        public ICollection<EventTeam> EventsParticipated { get; set; } = new List<EventTeam>();

        public ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();
    }
}
