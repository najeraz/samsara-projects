
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.BaseService.Impl;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class TenderService : GenericService<Tender, int, ITenderDao>, ITenderService
    {
        #region Methods

        public DataTable SearchTenderLines(TenderLineParameters pmtTenderLine)
        {
            return this.Dao.SearchTenderLines(pmtTenderLine);
        }

        public DataTable SearchTenderManufacturers(TenderManufacturerParameters
            pmtSearchTenderManufacturer)
        {
            return this.Dao.SearchTenderManufacturers(pmtSearchTenderManufacturer);
        }

        public DataTable SearchTenders(TenderParameters pmtTender)
        {
            return this.Dao.SearchTenders(pmtTender);
        }

        public Dictionary<int, Tender> LoadTenders()
        {
            return this.Dao.LoadTenders();
        }

        #endregion Methods
    }
}