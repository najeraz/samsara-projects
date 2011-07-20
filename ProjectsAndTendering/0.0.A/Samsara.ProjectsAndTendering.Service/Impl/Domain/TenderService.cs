﻿
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Parameters;
using System.Data;

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

        public DataTable SearchTenderManufacturers(SearchTenderManufacturersParameters
            pmtSearchTenderManufacturers)
        {
            return this.TenderDao.SearchTenderManufacturers(pmtSearchTenderManufacturers);
        }

        public DataTable SearchTenders(SearchTendersParameters pmtSearchTenders)
        {
            return this.TenderDao.SearchTenders(pmtSearchTenders);
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
            if (entity.TenderId < 0)
            {
                this.TenderDao.Save(entity);
            }
            else
            {
                this.TenderDao.Update(entity);
            }
        }

        public void DeleteTender(Tender entity)
        {
            this.TenderDao.Delete(entity);
        }

        #endregion Methods
    }
}