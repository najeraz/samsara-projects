﻿
using Samsara.Base.Service.Impl;
using Samsara.Commissions.Core.Parameters;
using Samsara.Commissions.Dao.Interfaces;
using Samsara.Commissions.Service.Interfaces;

namespace Samsara.Commissions.Service.Impl
{
    public class ServicesService : GenericService<Samsara.Commissions.Core.Entities.Service, int, IServiceDao, ServiceParameters>, IServiceService
    {
    }
}