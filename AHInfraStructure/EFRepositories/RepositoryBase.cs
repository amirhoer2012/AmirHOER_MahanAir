using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace AHInfraStructure.Repositories
{
    public abstract class RepositoryBase<TEntity, TId>
    where TEntity : AhEntityBase<TId>, new()
        where TId : struct, IComparable
    {

        protected readonly AHContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(AHContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return _dbSet.ToList();
        }

        public TEntity Persist(TEntity model)
        {
            var existEntity = Read;
            if (existEntity != null)
            {
               _dbSet.Update(model);
            }
            else
            {
                _dbSet.Add(model);
            }
            return model;
        }

        public virtual TEntity Read(TId id)
        {
           return _dbSet.SingleOrDefault(c => c.Id.Equals(id));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
