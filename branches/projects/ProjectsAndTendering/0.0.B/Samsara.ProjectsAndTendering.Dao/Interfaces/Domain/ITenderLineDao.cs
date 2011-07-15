using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface ITenderLineDao : IGenericDao<TenderLine,int>
    {
        Dictionary<int, TenderLine> LoadTenderLines();
    }
}
