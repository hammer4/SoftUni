namespace TeamBuilder.Models
{
    public class EventTeam
    {
        public int EventID { get; set; }
        public Event Event { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
