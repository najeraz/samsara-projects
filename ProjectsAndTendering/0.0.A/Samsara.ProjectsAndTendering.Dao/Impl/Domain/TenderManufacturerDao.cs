
using System.Collections.Generic;
using System.Linq;
using NHibernate.Impl;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class TenderManufacturerDao : GenericDao<TenderManufacturer, int>, ITenderManufacturerDao
    {
    }
}