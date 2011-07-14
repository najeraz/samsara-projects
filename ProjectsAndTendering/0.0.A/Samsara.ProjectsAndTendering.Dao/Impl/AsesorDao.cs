
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using uNhAddIns.NH.Impl;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.BaseDao.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl
{
    public class AsesorDao : GenericDao<Asesor, int>, IAsesorDao
    {
        #region Methods

        public Dictionary<int, Asesor> LoadAsesors()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadAsesors");

            return this.GetList(dnq).ToDictionary(x => x.AsesorId, x => x);
        }

        #endregion Methods
    }
}