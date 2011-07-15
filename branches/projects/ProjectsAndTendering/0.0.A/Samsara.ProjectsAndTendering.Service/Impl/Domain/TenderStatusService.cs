
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using System.Collections.Generic;

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

        public Dictionary<int, TenderStatus> LoadTenderStatuses()
        {
            return this.TenderStatusDao.LoadTenderStatuses();
        }

        public TenderStatus LoadTenderStatus(int TenderStatusId)
        {
            return this.TenderStatusDao.GetById(TenderStatusId);
        }

        public void SaveOrUpdateTenderStatus(TenderStatus asesor)
        {
            if (asesor.TenderStatusId > 0)
            {
                this.TenderStatusDao.Save(asesor);
            }
            else
            {
                this.TenderStatusDao.Update(asesor);
            }
        }

        public void DeleteTenderStatus(TenderStatus asesor)
        {
            this.TenderStatusDao.Delete(asesor);
        }

        #endregion Methods
    }
}