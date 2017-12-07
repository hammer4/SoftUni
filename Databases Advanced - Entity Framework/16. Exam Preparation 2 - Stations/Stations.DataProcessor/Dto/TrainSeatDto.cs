using System;
using System.Collections.Generic;
using System.Text;

namespace Stations.DataProcessor.Dto
{
    public class TrainSeatDto
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int? Quantity { get; set; }
    }
}
