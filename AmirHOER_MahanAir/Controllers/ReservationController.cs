using AHApplication.Services;
using AmirHOER_MahanAir.RequestDto;
using Application.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace AmirHOER_MahanAir.Controllers
{
    public class ReservationController:ControllerBase
    {
        private readonly IFligtReservationAppService _reservationAppService;

        public ReservationController(IFligtReservationAppService reservationAppService)
        {
            _reservationAppService = reservationAppService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationCreateRequest request)
        {
            try
            {
                var reservationModel = _reservationAppService.CreateReservation(request.UserId, request.FlightId);

                return Ok(reservationModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/reserve")]
        public IActionResult ReserveFlight(long id, [FromBody] ReservationReserveRequest request)
        {
            try
            {
                _reservationAppService.ReserveFlight(id, request.SeatQuantity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/confirm")]
        public IActionResult ConfirmReservation(long id)
        {
            try
            {
                _reservationAppService.ConfirmReservation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/reservation/{id}/cancel
        [HttpPut("{id}/cancel")]
        public IActionResult CancelReservation(long id)
        {
            try
            {
                _reservationAppService.CancelReservation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
