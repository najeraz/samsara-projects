
using System.Collections.Generic;
using System.Linq;
using NHibernate.Impl;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class AsesorDao : GenericDao<Asesor, int>, IAsesorDao
    {
    }
}