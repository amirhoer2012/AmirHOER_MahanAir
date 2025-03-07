using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IFligtReservationAppService
    {
        ReservationModel CreateReservation(int userId, long flightId);

        void ReserveFlight(long reservationId, int seatQuantity = 1);

        void ConfirmReservation(long reservationId);

        void CancelReservation(long reservationId);
    }
}
