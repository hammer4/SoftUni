using System;
using System.Collections.Generic;
using System.Text;

namespace Stations.DataProcessor.Dto
{
    public class TripDto
    {
        public string Train { get; set; }

        public string OriginStation { get; set; }

        public string DestinationStation { get; set; }

        public string DepartureTime { get; set; }

        public string ArrivalTime { get; set; }

        public string Status { get; set; }

        public string TimeDifference { get; set; }
    }
}
