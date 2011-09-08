
using Samsara.BaseService.Impl;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Dao.Interfaces;
using Samsara.Configuration.Service.Interfaces;

namespace Samsara.Configuration.Service.Impl
{
    public class FormConfigurationService : GenericService<FormConfiguration, int, IFormConfigurationDao, FormConfigurationParameters>, IFormConfigurationService
    {
    }
}