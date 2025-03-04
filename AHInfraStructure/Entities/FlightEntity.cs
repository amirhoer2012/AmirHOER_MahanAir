using AHDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHInfraStructure.Entities
{
    internal class FlightEntity: AhEntityBase
    {
        public long Id { get; set; }
        public string PlaneName { get; set; }
        public AirPortModel Source { get; set; }
        public AirPortModel Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }
    }
}
