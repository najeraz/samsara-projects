using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.BaseDao.Interfaces;
using System.Data;

namespace Samsara.ProjectsAndTendering.Dao.Interfaces.Domain
{
    public interface IAsesorDao : IGenericDao<Asesor, int>
    {
        Dictionary<int, Asesor> LoadAsesors();
        DataTable SearchAsesors(AsesorParameters pmtAsesor);
    }
}
