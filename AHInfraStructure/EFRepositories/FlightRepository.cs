using AHDomain.Models;
using Domain.Contracts.Repositories;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHInfraStructure.Repositories
{
    public class FlightRepository : RepositoryBase< FlightEntity, long>, IFlightRepository
    {
        public FlightRepository(AHContext context) : base(context)
        {
        }
    }
}
