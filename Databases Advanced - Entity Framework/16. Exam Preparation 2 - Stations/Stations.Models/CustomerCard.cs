using Stations.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stations.Models
{
    public class CustomerCard
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public CardType Type { get; set; }

        public ICollection<Ticket> BoughtTickets { get; set; }
    }
}
