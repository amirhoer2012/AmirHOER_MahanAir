using AHDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHInfraStructure.Entities
{
    internal class ReservationEntity: AhEntityBase
    {
        public int Id { get; private set; }
        public UserModel User { get; }
        public FlightModel Flight { get; }
        public ReservationState State { get; private set; }
        public DateTime ReserveDate { get; private set; }
        public DateTime? ConfirmationDate { get; private set; }
        public DateTime? CancellationDate { get; private set; }

    }
}
