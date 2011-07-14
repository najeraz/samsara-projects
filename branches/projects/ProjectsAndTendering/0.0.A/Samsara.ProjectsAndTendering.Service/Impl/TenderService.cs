
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Parameters;
using System.Data;

namespace Samsara.ProjectsAndTendering.Service.Impl
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

        public DataTable SearchTenders(TenderSearchParameters pmtTenderSearch)
        {
            return this.TenderDao.SearchTenders(pmtTenderSearch);
        }

        public Dictionary<int, Tender> LoadTenders()
        {
            return this.TenderDao.LoadTenders();
        }

        public Tender LoadTender(int TenderId)
        {
            return this.TenderDao.GetById(TenderId);
        }

        public void SaveOrUpdateTender(Tender asesor)
        {
            if (asesor.TenderId > 0)
            {
                this.TenderDao.Save(asesor);
            }
            else
            {
                this.TenderDao.Update(asesor);
            }
        }

        public void DeleteTender(Tender asesor)
        {
            this.TenderDao.Delete(asesor);
        }

        #endregion Methods
    }
}