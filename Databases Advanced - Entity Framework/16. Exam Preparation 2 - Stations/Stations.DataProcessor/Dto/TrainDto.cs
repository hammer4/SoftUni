using System;
using System.Collections.Generic;
using System.Text;

namespace Stations.DataProcessor.Dto
{
    public class TrainDto
    {
        public string TrainNumber { get; set; }
        public string Type { get; set; }
        public ICollection<TrainSeatDto> Seats { get; set; }
    }
}
