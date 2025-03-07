using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Repositories;
using Domain.Contracts.DomainServices;
using Domain.Models;
using Entities.Entities;

namespace Domain.DomainServices
{
    public class AirPortDomainService: DomainServiceBase<AirPortModel,AirPortEntity,int>,IAirPortDomainService
    {
        private readonly IAirPortRepository repository;

        public AirPortDomainService(IAirPortRepository repository)
        : base(repository) 
        {
            this.repository = repository;
        }
        
        protected override AirPortEntity Map(AirPortModel model)
        {
            return new AirPortEntity
            {
                Id = model.Id,
                AirPortName = model.AirPortName,
                LastChangeDate = DateTime.Now
            };
        }

        protected override AirPortModel Map(AirPortEntity entity)
        {
            return new AirPortModel(entity);
        }
    }
}
