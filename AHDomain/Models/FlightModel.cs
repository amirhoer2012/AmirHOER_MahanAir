using Entities.Entities;

namespace Domain.Models
{
    public class FlightModel : ModelBase
    {
        public FlightModel(FlightEntity entity)
        {
            Id = entity.Id;
            Destination = new AirPortModel(entity.Destination);
            Source = new AirPortModel(entity.Source);
            DepartureTime = entity.DepartureTime;
            PlaneName = entity.PlaneName;
            AvailableSeats = entity.AvailableSeats;
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

        public void ChangeDestination(AirPortModel newDestination, DateTime? newDepartureTime = null)
        {
            Destination = newDestination;
            if (newDepartureTime != null)
            {
                DepartureTime = (DateTime)newDepartureTime;
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
