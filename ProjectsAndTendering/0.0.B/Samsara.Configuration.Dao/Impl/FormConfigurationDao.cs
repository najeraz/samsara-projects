
using Samsara.Base.Dao.Impl;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Dao.Interfaces;

namespace Samsara.Configuration.Dao.Impl
{
    public class FormConfigurationDao : GenericDao<FormConfiguration, int, FormConfigurationParameters>, IFormConfigurationDao
    {
    }
}