using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces
{
    public interface IAsesorDao : IGenericDao<Asesor,int>
    {
        Dictionary<int, Asesor> LoadAsesors();
    }
}
