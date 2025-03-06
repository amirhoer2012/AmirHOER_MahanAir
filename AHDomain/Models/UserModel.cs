using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace AHDomain.Models
{
    public class UserModel: ModelBase
    {
        public UserModel(UserEntity entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Family = entity.Family;
            this.PhoneNo = entity.PhoneNo;
            this.Username = entity.Username;
            this.Password = entity.Password;
        }

        public UserModel(int id, string username, string password,
            string? name = null , string? family = null , string? phoneNo = null)
        {
            Id = id;
            Name = name ?? username;
            Family = family ?? string.Empty;
            PhoneNo = phoneNo ?? string.Empty;
            Username = username;
            Password = password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
