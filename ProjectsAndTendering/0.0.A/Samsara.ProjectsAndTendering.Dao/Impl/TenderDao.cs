
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using System.Collections.Generic;
using uNhAddIns.NH.Impl;
using System.Linq;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using System.Data;

namespace Samsara.ProjectsAndTendering.Dao.Impl
{
    public class TenderDao : GenericDao<Tender, int>, ITenderDao
    {
        #region Methods

        public DataTable SearchTenders(TenderSearchParameters pmtTenderSearch)
        {
            return this.DataTableByObjectProperties("SearchTenders", pmtTenderSearch);
        }

        public Dictionary<int, Tender> LoadTenders()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadTenders");

            return this.GetList(dnq).ToDictionary(x => x.TenderId, x => x);
        }

        #endregion Methods
    }
}