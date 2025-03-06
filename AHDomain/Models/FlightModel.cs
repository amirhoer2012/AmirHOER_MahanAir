

using Entities.Entities;

namespace AHDomain.Models
{
    public class FlightModel: ModelBase
    {
        public FlightModel(FlightEntity entity)
        {
            this.Id = entity.Id;
            this.Destination = new AirPortModel(entity.Destination);
            this.Source = new AirPortModel(entity.Source);
            this.DepartureTime = entity.DepartureTime;
            this.PlaneName = entity.PlaneName;
            this.AvailableSeats = entity.AvailableSeats;
        }

        public FlightModel(long id, string planeName, int sourceId, int destinationId, DateTime departureTime, int availableSeats)
        {
            Id = id;
            PlaneName = planeName;
            SourceId = sourceId;
            DestinationId = destinationId;
            DepartureTime = departureTime;
            AvailableSeats = availableSeats;
        }

        public void ChangeDestination(AirPortModel newDestination,DateTime? newDepartureTime = null)
        {
            this.Destination = newDestination;
            if (newDepartureTime != null)
            {
                this.DepartureTime = (DateTime)newDepartureTime;
            }
        }

        public long Id { get; }
        public string PlaneName { get; set; }
        public AirPortModel Source { get; set; }
        public AirPortModel Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }
        private int SourceId { get; }
        private int DestinationId { get; }
    }
}
