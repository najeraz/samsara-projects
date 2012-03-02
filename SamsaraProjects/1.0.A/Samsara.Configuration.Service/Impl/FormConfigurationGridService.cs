﻿
using Samsara.Base.Service.Impl;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Dao.Interfaces;
using Samsara.Configuration.Service.Interfaces;

namespace Samsara.Configuration.Service.Impl
{
    public class FormConfigurationGridService : GenericService<FormConfigurationGrid, int, IFormConfigurationGridDao, FormConfigurationGridParameters>, IFormConfigurationGridService
    {
    }
}