﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDomain.Models;

namespace Application.Contracts.DomainServices
{
    public interface IDomainServiceBase<TModel,in TId>
    where TModel : ModelBase
    where TId : struct
    {
        IEnumerable<TModel> ReadAll();

        TModel Persist(TModel model);

        TModel Read(TId id);
    }
}
