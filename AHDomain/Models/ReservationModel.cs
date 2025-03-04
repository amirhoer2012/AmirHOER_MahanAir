namespace AHDomain.Models
{
    public enum ReservationState
    {
        NotReserved,
        TempReserved,
        Reserved,
        Cancelled
    }

    public class ReservationModel
    {
        #region Ctor
        
        public ReservationModel(UserModel user, FlightModel flight)
        {
            this.User = user;
            this.Flight = flight;
            this.State = ReservationState.NotReserved;
        } 

        #endregion

        public void ReserveFlight(int id, DateTime reserveDate)
        {
            this.Id = id;
            this.ReserveDate = reserveDate;
            this.State = ReservationState.TempReserved;
        }

        public void ConfirmReserve(DateTime confirmationDate)
        {
            this.ConfirmationDate = confirmationDate;
            this.State = ReservationState.Reserved;
        }

        public void CancelReserve(DateTime cancellationDate)
        {
            this.CancellationDate = cancellationDate;
            this.State = ReservationState.Cancelled;
        }

        #region Properties

        public int Id { get; private set; }
        public UserModel User { get; }
        public FlightModel Flight { get; }
        public ReservationState State { get; private set; }
        public DateTime ReserveDate { get; private set; }
        public DateTime? ConfirmationDate { get; private set; }
        public DateTime? CancellationDate { get; private set; }

        #endregion
    }
}
