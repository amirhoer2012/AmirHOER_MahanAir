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
    public class ReservationRepository : RepositoryBase<ReservationEntity, long>, IReservationRepository
    {
        public ReservationRepository(AHContext context) : base(context)
        {
        }
    }
}
