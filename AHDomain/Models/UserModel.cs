using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace Domain.Models
{
    public class UserModel : ModelBase
    {
        public UserModel(UserEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Family = entity.Family;
            PhoneNo = entity.PhoneNo;
            Username = entity.Username;
            Password = entity.Password;
        }

        public UserModel(int id, string username, string password,
            string? name = null, string? family = null, string? phoneNo = null)
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
