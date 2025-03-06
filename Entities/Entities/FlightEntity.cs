using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class FlightEntity : AhEntityBase<long>
    {
        public string PlaneName { get; set; }
        public AirPortEntity Source { get; set; }
        public AirPortEntity Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }
        public int SourceId { get; set; }
        public int DestinationId { get; set; }
    }
}
