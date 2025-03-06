using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ReservationEntity : AhEntityBase<long>
    {
        public UserEntity User { get; }
        public FlightEntity Flight { get; }
        public short State { get; set; }
        public int SeatQuantity { get; set; }
        public DateTime ReserveDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? CancellationDate { get; set; }
        public int UserId { get; set; }
        public long  FlightId { get; set; }

    }
}
