
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using System.Collections.Generic;
using System.Linq;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.BaseDao.Impl;
using System.Data;
using NHibernate.Impl;

namespace Samsara.ProjectsAndTendering.Dao.Impl.Domain
{
    public class TenderDao : GenericDao<Tender, int>, ITenderDao
    {
        #region Methods

        public DataTable SearchTenders(SearchTendersParameters pmtSearchTenders)
        {
            return this.DataTableByObjectProperties("SearchTenders", pmtSearchTenders);
        }

        public DataTable SearchTenderLines(SearchTenderLinesParameters
            pmtSearchTenderLines)
        {
            return this.DataTableTypedByObjectProperties<TenderLine>(
                "SearchTenderLines", pmtSearchTenderLines);
        }

        public DataTable SearchTenderManufacturers(SearchTenderManufacturerParameters
            pmtSearchTenderManufacturer)
        {
            return this.DataTableTypedByObjectProperties<TenderManufacturer>(
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