using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public abstract class AhEntityBase<TId>
    where TId : struct, IComparable
    {
        public TId Id { get; set; }
        public DateTime LastChangeDate { get; set; }

        public abstract void Update(AhEntityBase<TId> updatedEntity);
    }
}
