﻿
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class TenderStatusService : BaseService, ITenderStatusService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public ITenderStatusDao TenderStatusDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public DataTable SearchTenderStatuses(SearchTenderStatusesParameters pmtSearchTenderStatuses)
        {
            return this.TenderStatusDao.SearchTenderStatuses(pmtSearchTenderStatuses);
        }

        public Dictionary<int, TenderStatus> LoadTenderStatuses()
        {
            return this.TenderStatusDao.LoadTenderStatuses();
        }

        public TenderStatus LoadTenderStatus(int TenderStatusId)
        {
            return this.TenderStatusDao.GetById(TenderStatusId);
        }

        public void SaveOrUpdateTenderStatus(TenderStatus entity)
        {
            if (entity.TenderStatusId < 0)
            {
                this.TenderStatusDao.Save(entity);
            }
            else
            {
                this.TenderStatusDao.Update(entity);
            }
        }

        public void DeleteTenderStatus(TenderStatus entity)
        {
            this.TenderStatusDao.Delete(entity);
        }

        #endregion Methods
    }
}