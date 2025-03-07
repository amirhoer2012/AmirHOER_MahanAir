using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace Domain.Repositories
{
    public interface IRepositoryBase<TEntity, TId>
    where TEntity : AhEntityBase<TId>
    where TId : struct, IComparable
    {
        IEnumerable<TEntity> ReadAll();

        TEntity Persist(TEntity model);

        TEntity Read(TId id);

        void SaveChanges();
    }
}
