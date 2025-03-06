using AHDomain.Models;
using Application.Contracts.DomainServices;
using Domain.Contracts.Repositories;
using Entities.Entities;

namespace Domain.DomainServices
{
    public abstract class DomainServiceBase<TModel,TEntity,TId>:IDomainServiceBase<TModel,TId>
    where TModel : ModelBase
    where TEntity : AhEntityBase<TId>
    where TId :struct,IComparable
    {
        private readonly IRepositoryBase<TEntity,TId> repository;

        protected DomainServiceBase(IRepositoryBase<TEntity, TId> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<TModel> ReadAll()
        {
            return repository.ReadAll().Select(Map);
        }

        public TModel Persist(TModel model)
        {
            return Map(this.repository.Persist(Map(model)));
        }

        public TModel Read(TId id)
        {
            return Map(this.repository.Read(id));
        }

        public void SaveChanges()
        {
            this.repository.SaveChanges();
        }

        protected abstract TEntity Map(TModel model);

        protected abstract TModel Map(TEntity entity);
    }
}
