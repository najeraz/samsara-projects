
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using System.Collections.Generic;
using System.Linq;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using NHibernate.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class TenderLineDao : GenericDao<TenderLine, int>, ITenderLineDao
    {
        #region Methods

        public Dictionary<int, TenderLine> LoadTenderLines()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadTenderLines");

            return this.GetList(dnq).ToDictionary(x => x.TenderLineId, x => x);
        }

        #endregion Methods
    }
}