using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDomain.Models;
using Domain.Contracts.Repositories;
using Entities.Entities;

namespace AHInfraStructure.Repositories
{
    public class AirPortRepository : RepositoryBase< AirPortEntity, int>, IAirPortRepository
    {
        public AirPortRepository(AHContext context) : base(context)
        {
        }
    }
}
