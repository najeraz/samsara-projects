
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate.Impl;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class TenderDao : GenericDao<Tender, int>, ITenderDao
    {
        #region Methods

        public DataTable SearchTenders(SearchTendersParameters pmtSearchTenders)
        {
            return this.DataTableByParameters("SearchTenders", pmtSearchTenders);
        }

        public DataTable SearchTenderLines(SearchTenderLinesParameters
            pmtSearchTenderLines)
        {
            return this.DataTableTypedByParameters<TenderLine>(
                "SearchTenderLines", pmtSearchTenderLines);
        }

        public DataTable SearchTenderManufacturers(SearchTenderManufacturerParameters
            pmtSearchTenderManufacturer)
        {
            return this.DataTableTypedByParameters<TenderManufacturer>(
                "SearchTenderManufacturers", pmtSearchTenderManufacturer);
        }

        public Dictionary<int, Tender> LoadTenders()
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("LoadTenders");

            return this.GetList(dnq).ToDictionary(x => x.TenderId, x => x);
        }

        #endregion Methods
    }
}