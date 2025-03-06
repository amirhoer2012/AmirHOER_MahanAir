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
    public class ReservationRepository : RepositoryBase<ReservationEntity, long>, IReservationRepository
    {
        public ReservationRepository(AHContext context) : base(context)
        {
        }
    }
}
