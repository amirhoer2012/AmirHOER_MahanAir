using AHDomain.Models;
using Domain.Contracts.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Entities.Entities;

namespace Domain.DomainServices
{
    internal class UserDomainService : DomainServiceBase<UserModel,UserEntity, int>, IUserDomainService
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
