﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHInfraStructure.Entities
{
    internal class AirPortEntity: AhEntityBase
    {
        public int Id { get; set; }
        public string AirPortName { get; set; }
    }
}
