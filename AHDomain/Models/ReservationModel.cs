using Domain.Enum;
using Entities.Entities;

namespace AHDomain.Models
{
    public class ReservationModel : ModelBase
    {
        private const int VALID_RESERVATION_PERIOD_BEFORE_FLIGHT = 1;

        #region Ctor

        public ReservationModel(ReservationEntity entity)
        {
            this.Id = entity.Id;
            this.State = (ReservationState)entity.State;
            this.CancellationDate = entity.CancellationDate;
            this.ConfirmationDate = entity.ConfirmationDate;
            this.Flight = new FlightModel(entity.Flight);
            this.User = new UserModel(entity.User);
            this.ReserveDate = entity.ReserveDate;
            this.SeatQuantity = entity.SeatQuantity;
        }

        public ReservationModel(UserModel user, FlightModel flight)
        {
            this.User = user;
            this.Flight = flight;
            this.State = ReservationState.Initialized;
        }

        #endregion

        public void ReserveFlight(long id, DateTime reserveDate, int seatQuantity = 1)
        {
            if (ValidateToTempReserve(id, reserveDate, seatQuantity))
            {
                this.Id = id;
                this.ReserveDate = reserveDate;
                this.State = ReservationState.TempReserved;
                this.SeatQuantity = seatQuantity;
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
                this.ConfirmationDate = confirmationDate;
                this.State = ReservationState.Reserved;
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
                this.CancellationDate = cancellationDate;
                this.State = ReservationState.Cancelled;
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
                   this.State == ReservationState.Initialized &&
                   ValidateDate(reserveDate);
        }

        private bool ValidateToConfirmReserve(DateTime confirmationDate)
        {
            return ValidateDate(confirmationDate) &&
                   confirmationDate > this.ReserveDate &&
                   this.State == ReservationState.TempReserved &&
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
