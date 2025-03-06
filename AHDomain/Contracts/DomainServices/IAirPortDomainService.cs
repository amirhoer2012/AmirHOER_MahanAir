﻿using Application.Contracts.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AHDomain.Models;

namespace Domain.Contracts.DomainServices
{
    public interface IAirPortDomainService: IDomainServiceBase<AirPortModel,int>
    {
    }
}
