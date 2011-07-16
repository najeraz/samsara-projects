
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class TenderLineService : BaseService, ITenderLineService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public ITenderLineDao TenderLineDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public Dictionary<int, TenderLine> LoadTenderLines()
        {
            return this.TenderLineDao.LoadTenderLines();
        }

        public TenderLine LoadTenderLine(int TenderLineId)
        {
            return this.TenderLineDao.GetById(TenderLineId);
        }

        public void SaveOrUpdateTenderLine(TenderLine entity)
        {
            if (entity.TenderLineId < 0)
            {
                this.TenderLineDao.Save(entity);
            }
            else
            {
                this.TenderLineDao.Update(entity);
            }
        }

        public void DeleteTenderLine(TenderLine entity)
        {
            this.TenderLineDao.Delete(entity);
        }

        #endregion Methods
    }
}