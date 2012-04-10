
using Samsara.Base.Dao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;

namespace Samsara.ProjectsAndTendering.Dao.Impl
{
    public class OrganizationDao : BaseDao<Organization, int, OrganizationParameters>, IOrganizationDao
    {
    }
}