using Domain.Contracts.DomainServices;
using Domain.Repositories;
using Domain.Models;
using Entities.Entities;

namespace Domain.DomainServices
{
    public class UserDomainService : DomainServiceBase<UserModel,UserEntity, int>, IUserDomainService
    {
        private readonly IUserRepository repository;

        public UserDomainService(IUserRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        
        protected override UserEntity Map(UserModel model)
        {
            return new UserEntity
            {
                LastChangeDate = DateTime.Now,
                Family = model.Family,
                PhoneNo = model.PhoneNo,
                Username = model.Username,
                Password = model.Password,
                Id = model.Id,
                Name = model.Name
            };
        }

        protected override UserModel Map(UserEntity entity)
        {
            return new UserModel(entity);
        }
    }
}
