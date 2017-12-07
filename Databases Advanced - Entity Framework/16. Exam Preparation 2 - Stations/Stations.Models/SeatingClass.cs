using System;
using System.Collections.Generic;
using System.Text;

namespace Stations.Models
{
    public class SeatingClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public ICollection<TrainSeat> TrainSeats { get; set; }
    }
}
