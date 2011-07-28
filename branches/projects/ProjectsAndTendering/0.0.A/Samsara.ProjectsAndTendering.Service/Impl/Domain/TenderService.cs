
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class TenderService : BaseService, ITenderService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public ITenderDao TenderDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public DataTable SearchTenderLines(TenderLineParameters pmtTenderLine)
        {
            return this.TenderDao.SearchTenderLines(pmtTenderLine);
        }

        public DataTable SearchTenderManufacturers(TenderManufacturerParameters
            pmtSearchTenderManufacturer)
        {
            return this.TenderDao.SearchTenderManufacturers(pmtSearchTenderManufacturer);
        }

        public DataTable SearchTenders(TenderParameters pmtTender)
        {
            return this.TenderDao.SearchTenders(pmtTender);
        }

        public Dictionary<int, Tender> LoadTenders()
        {
            return this.TenderDao.LoadTenders();
        }

        public Tender LoadTender(int TenderId)
        {
            return this.TenderDao.GetById(TenderId);
        }

        public void SaveOrUpdateTender(Tender entity)
        {
            this.TenderDao.SaveOrUpdate(entity);
        }

        public void DeleteTender(Tender entity)
        {
            this.TenderDao.Delete(entity);
        }

        #endregion Methods
    }
}