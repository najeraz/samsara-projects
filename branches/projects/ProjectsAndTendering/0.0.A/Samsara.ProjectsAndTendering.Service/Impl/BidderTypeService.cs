
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using System.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Service.Impl
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

        public void SaveOrUpdateBidderType(BidderType asesor)
        {
            if (asesor.BidderTypeId > 0)
            {
                this.BidderTypeDao.Save(asesor);
            }
            else
            {
                this.BidderTypeDao.Update(asesor);
            }
        }

        public void DeleteBidderType(BidderType asesor)
        {
            this.BidderTypeDao.Delete(asesor);
        }

        #endregion Methods
    }
}