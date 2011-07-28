
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
        #region Methods

        public DataTable SearchAsesors(AsesorParameters pmtAsesor)
        {
            return this.DataTableByParameters("SearchAsesors", pmtAsesor);
        }

        public Dictionary<int, Asesor> LoadAsesors()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadAsesors");

            return this.GetList(dnq).ToDictionary(x => x.AsesorId, x => x);
        }

        #endregion Methods
    }
}