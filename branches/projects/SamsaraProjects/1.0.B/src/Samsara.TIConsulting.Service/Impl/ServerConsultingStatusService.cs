﻿
using Samsara.Base.Service.Impl;
using Samsara.TIConsulting.Core.Entities;
using Samsara.TIConsulting.Core.Parameters;
using Samsara.TIConsulting.Dao.Interfaces;
using Samsara.TIConsulting.Service.Interfaces;

namespace Samsara.TIConsulting.Service.Impl
{
    public class ServerConsultingStatusService : BaseService<ServerConsultingStatus, int, IServerConsultingStatusDao, ServerConsultingStatusParameters>, IServerConsultingStatusService
    {
    }
}