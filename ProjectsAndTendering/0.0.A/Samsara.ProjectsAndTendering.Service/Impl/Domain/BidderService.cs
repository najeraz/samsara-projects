
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
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

        public DataTable SearchBidders(BidderParameters pmtBidder)
        {
            return this.BidderDao.SearchBidders(pmtBidder);
        }

        public Dictionary<int, Bidder> LoadBidders(BidderParameters pmtBidder)
        {
            return this.BidderDao.LoadBidders(pmtBidder);
        }

        public Bidder LoadBidder(int BidderId)
        {
            return this.BidderDao.GetById(BidderId);
        }

        public void SaveOrUpdateBidder(Bidder entity)
        {
            if (entity.BidderId < 0)
            {
                this.BidderDao.Save(entity);
            }
            else
            {
                this.BidderDao.Update(entity);
            }
        }

        public void DeleteBidder(Bidder entity)
        {
            this.BidderDao.Delete(entity);
        }

        #endregion Methods
    }
}