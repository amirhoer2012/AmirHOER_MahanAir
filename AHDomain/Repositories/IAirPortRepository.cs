using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace Domain.Repositories
{
    public interface IAirPortRepository : IRepositoryBase<AirPortEntity, int>
    {
    }
}
