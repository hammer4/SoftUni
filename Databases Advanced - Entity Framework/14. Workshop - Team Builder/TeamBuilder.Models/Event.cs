namespace TeamBuilder.Models
{
    using System;
    using System.Collections.Generic;

    public class Event
    {
        private DateTime endDate;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate
        {
            get => this.endDate;
            set
            {
                if (value <= this.StartDate)
                {
                    throw new ArgumentException("Start date should be before end date.");
                }

                this.endDate = value;
            }
        }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<EventTeam> ParticipatingEventTeams { get; set; } = new List<EventTeam>();
    }
}
