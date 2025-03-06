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
    public class UserRepository : RepositoryBase< UserEntity, int>, IUserRepository
    {
        public UserRepository(AHContext context) : base(context)
        {
        }
    }
}
