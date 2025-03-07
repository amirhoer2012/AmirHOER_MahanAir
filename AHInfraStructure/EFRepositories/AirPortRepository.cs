using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Entities.Entities;
using InfraStructure;

namespace InfraStructure.EFRepositories
{
    public class AirPortRepository : RepositoryBase<AirPortEntity, int>, IAirPortRepository
    {
        public AirPortRepository(AHContext context) : base(context)
        {
        }
    }
}
