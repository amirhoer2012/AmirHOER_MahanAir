using Application.Contracts;
using Domain.Contracts.DomainServices;
using Domain.Models;

namespace AHApplication.Services
{
    public class FlightReservationAppService : IFligtReservationAppService
    {
        private readonly IReservationDomainService _reservationservice;
        private readonly IFlightDomainService _flightService;
        private readonly IUserDomainService _userService;

        public FlightReservationAppService(
            IReservationDomainService reservationRepository,
            IFlightDomainService flightRepository,
            IUserDomainService userRepository)
        {
            _reservationservice = reservationRepository;
            _flightService = flightRepository;
            _userService = userRepository;
        }

        public ReservationModel CreateReservation(int userId, long flightId)
        {
            var flight = _flightService.Read(flightId);
            var user = _userService.Read(userId);

            if (flight == null)
                throw new Exception("Flight not found.");
            if (user == null)
                throw new Exception("User not found.");

            var reservationEntity = new ReservationModel(user, flight);

            _reservationservice.Persist(reservationEntity);
            _reservationservice.SaveChanges();

            return reservationEntity;
        }

        public void ReserveFlight(long reservationId, int seatQuantity = 1)
        {
            var reservationModel = _reservationservice.Read(reservationId);

            if (reservationModel == null)
                throw new Exception("Reservation not found.");

            reservationModel.ReserveFlight(reservationId, DateTime.Now, seatQuantity);

            _reservationservice.Persist(reservationModel);
            _reservationservice.SaveChanges();
        }

        public void ConfirmReservation(long reservationId)
        {
            var reservationModel = _reservationservice.Read(reservationId);

            if (reservationModel == null)
                throw new Exception("Reservation not found.");

            reservationModel.ConfirmReserve(DateTime.Now);

            _reservationservice.Persist(reservationModel);
            _reservationservice.SaveChanges();
        }

        public void CancelReservation(long reservationId)
        {
            var reservationModel = _reservationservice.Read(reservationId);

            if (reservationModel == null)
                throw new Exception("Reservation not found.");

            reservationModel.CancelReserve(DateTime.Now);

            _reservationservice.Persist(reservationModel);
            _reservationservice.SaveChanges();
        }
    }
}
