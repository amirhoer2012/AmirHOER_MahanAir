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
    public class FlightDomainService : DomainServiceBase<FlightModel, FlightEntity, long>, IFlightDomainService
    {
        private readonly IFlightRepository repository;

        public FlightDomainService(IFlightRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

        protected override FlightEntity Map(FlightModel model)
        {
            return new FlightEntity()
            {
                DepartureTime = model.DepartureTime,
                AvailableSeats = model.AvailableSeats,
                LastChangeDate = DateTime.Now,
                DestinationId = model.Destination.Id,
                Id = model.Id,
                PlaneName = model.PlaneName,
                SourceId = model.Source.Id,
            };
        }

        protected override FlightModel Map(FlightEntity entity)
        {
            return new FlightModel(entity);
        }
    }
}
