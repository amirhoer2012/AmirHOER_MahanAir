using Domain.Repositories;
using Entities.Entities;
using InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.EFRepositories
{
    public class FlightRepository : RepositoryBase<FlightEntity, long>, IFlightRepository
    {
        public FlightRepository(AHContext context) : base(context)
        {
        }
    }
}
