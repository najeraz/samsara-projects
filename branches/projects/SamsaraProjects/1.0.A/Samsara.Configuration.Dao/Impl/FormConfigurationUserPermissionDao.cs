
using Samsara.Base.Dao.Impl;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Dao.Interfaces;

namespace Samsara.Configuration.Dao.Impl
{
    public class FormConfigurationUserPermissionDao : GenericDao<FormConfigurationUserPermission, int, FormConfigurationUserPermissionParameters>, IFormConfigurationUserPermissionDao
    {
    }
}