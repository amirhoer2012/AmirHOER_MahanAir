using Domain.Enum;
using Entities.Entities;

namespace Domain.Models
{
    public class ReservationModel : ModelBase
    {
        private const int VALID_RESERVATION_PERIOD_BEFORE_FLIGHT = 1;

        #region Ctor

        public ReservationModel(ReservationEntity entity)
        {
            Id = entity.Id;
            State = (ReservationState)entity.State;
            CancellationDate = entity.CancellationDate;
            ConfirmationDate = entity.ConfirmationDate;
            Flight = new FlightModel(entity.Flight);
            User = new UserModel(entity.User);
            ReserveDate = entity.ReserveDate;
            SeatQuantity = entity.SeatQuantity;
        }

        public ReservationModel(UserModel user, FlightModel flight)
        {
            User = user;
            Flight = flight;
            State = ReservationState.Initialized;
        }

        #endregion

        public void ReserveFlight(long id, DateTime reserveDate, int seatQuantity = 1)
        {
            if (ValidateToTempReserve(id, reserveDate, seatQuantity))
            {
                Id = id;
                ReserveDate = reserveDate;
                State = ReservationState.TempReserved;
                SeatQuantity = seatQuantity;
            }
            else
            {
                throw new Exception($"Can not reserve flight for {seatQuantity} people in {reserveDate}");
            }
        }

        public void ConfirmReserve(DateTime confirmationDate)
        {
            if (ValidateToConfirmReserve(confirmationDate))
            {
                ConfirmationDate = confirmationDate;
                State = ReservationState.Reserved;
            }
            else
            {
                throw new Exception($"Can not confirm reserved flight in {confirmationDate}");
            }
        }

        public void CancelReserve(DateTime cancellationDate)
        {
            if (ValidateToCancel(cancellationDate))
            {
                CancellationDate = cancellationDate;
                State = ReservationState.Cancelled;
            }
            else
            {
                throw new Exception($"Can not Cancel reserved flight in {cancellationDate}");
            }
        }

        #region Properties

        public long Id { get; private set; }
        public UserModel User { get; }
        public FlightModel Flight { get; }
        public int SeatQuantity { get; set; }
        public ReservationState State { get; private set; }
        public DateTime ReserveDate { get; private set; }
        public DateTime? ConfirmationDate { get; private set; }
        public DateTime? CancellationDate { get; private set; }

        #endregion

        private bool ValidateToTempReserve(long id, DateTime reserveDate, int seatQuantity = 1)
        {
            return id > 0 && seatQuantity > 0 &&
                   State == ReservationState.Initialized &&
                   ValidateDate(reserveDate);
        }

        private bool ValidateToConfirmReserve(DateTime confirmationDate)
        {
            return ValidateDate(confirmationDate) &&
                   confirmationDate > ReserveDate &&
                   State == ReservationState.TempReserved &&
                   confirmationDate.AddHours(VALID_RESERVATION_PERIOD_BEFORE_FLIGHT) < confirmationDate;
        }

        private bool ValidateToCancel(DateTime cancellationDate)
        {
            return ValidateDate(cancellationDate);

        }

        private bool ValidateDate(DateTime date)
        {
            return date != DateTime.MinValue && date != DateTime.MaxValue;
        }
    }
}
