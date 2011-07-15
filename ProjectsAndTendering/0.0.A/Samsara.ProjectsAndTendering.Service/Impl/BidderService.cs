
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using System.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Service.Impl
{
    public class BidderService : BaseService, IBidderService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IBidderDao BidderDao
        {
            get;
            set;
        }

        #endregion Properties
        
        #region Methods
        
        public Dictionary<int, Bidder> LoadBidders()
        {
            return this.BidderDao.LoadBidders();
        }

        public Bidder LoadBidder(int BidderId)
        {
            return this.BidderDao.GetById(BidderId);
        }

        public void SaveOrUpdateBidder(Bidder asesor)
        {
            if (asesor.BidderId > 0)
            {
                this.BidderDao.Save(asesor);
            }
            else
            {
                this.BidderDao.Update(asesor);
            }
        }

        public void DeleteBidder(Bidder asesor)
        {
            this.BidderDao.Delete(asesor);
        }

        #endregion Methods
    }
}