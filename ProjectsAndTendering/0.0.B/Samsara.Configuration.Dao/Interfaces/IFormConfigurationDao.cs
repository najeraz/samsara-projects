
using Samsara.BaseDao.Interfaces;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;

namespace Samsara.Configuration.Dao.Interfaces
{
    public interface IFormConfigurationDao : IGenericDao<FormConfiguration, int, FormConfigurationParameters>
    {
    }
}
