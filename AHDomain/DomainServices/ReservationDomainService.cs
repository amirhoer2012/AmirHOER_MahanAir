using Domain.Contracts.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Entities.Entities;
using Domain.Models;

namespace Domain.DomainServices
{
    public class ReservationDomainService : DomainServiceBase<ReservationModel,ReservationEntity, long>, IReservationDomainService
    {
        private readonly IReservationRepository repository;

        public ReservationDomainService(IReservationRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        protected override ReservationEntity Map(ReservationModel model)
        {
            return new ReservationEntity
            {
                LastChangeDate = DateTime.Now,
                FlightId = model.Flight.Id,
                SeatQuantity = model.SeatQuantity,
                UserId = model.User.Id,
                State = (short)model.State,
                ReserveDate = model.ReserveDate,
                CancellationDate = model.CancellationDate,
                ConfirmationDate = model.ConfirmationDate,
                Id = model.Id,
            };
        }

        protected override ReservationModel Map(ReservationEntity entity)
        {
            return new ReservationModel(entity);
        }
    }
}
