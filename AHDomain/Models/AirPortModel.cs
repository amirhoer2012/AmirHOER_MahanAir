using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace Domain.Models
{
    public class AirPortModel : ModelBase
    {
        public AirPortModel(AirPortEntity entity)
        {
            Id = entity.Id;
            AirPortName = entity.AirPortName;
        }

        public AirPortModel(int id, string airPortName)
        {
            Id = id;
            AirPortName = airPortName;
        }

        public int Id { get; set; }
        public string AirPortName { get; set; }
    }
}
