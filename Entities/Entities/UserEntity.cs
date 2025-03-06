using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserEntity : AhEntityBase<int>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
