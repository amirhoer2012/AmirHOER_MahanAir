using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace Domain.Contracts.Repositories
{
    public interface IReservationRepository : IRepositoryBase<ReservationEntity, long>
    {
    }
}
