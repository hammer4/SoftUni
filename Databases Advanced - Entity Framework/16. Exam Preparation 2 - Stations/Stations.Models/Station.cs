using System.Collections.Generic;

namespace Stations.Models
{
    public class Station
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Town { get; set; }

        public ICollection<Trip> TripsTo { get; set; }

        public ICollection<Trip> TripsFrom { get; set; }
    }
}
