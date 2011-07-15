
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using System.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class BidderTypeService : BaseService, IBidderTypeService
    {

        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IBidderTypeDao BidderTypeDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public Dictionary<int, BidderType> LoadBidderTypes()
        {
            return this.BidderTypeDao.LoadBidderTypes();
        }

        public BidderType LoadBidderType(int BidderTypeId)
        {
            return this.BidderTypeDao.GetById(BidderTypeId);
        }

        public void SaveOrUpdateBidderType(BidderType entity)
        {
            if (entity.BidderTypeId > 0)
            {
                this.BidderTypeDao.Save(entity);
            }
            else
            {
                this.BidderTypeDao.Update(entity);
            }
        }

        public void DeleteBidderType(BidderType entity)
        {
            this.BidderTypeDao.Delete(entity);
        }

        #endregion Methods
    }
}