
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class BidderForm : BidderSearchForm
    {
        #region Attributes

        private BidderFormController ctrlBidderForm;
        private IBidderService srvBidder;

        #endregion Attributes

        public BidderForm()
        {
            InitializeComponent();
            this.ctrlBidderForm = new BidderFormController(this);
            this.srvBidder = SamsaraAppContext.Resolve<IBidderService>();
            Assert.IsNotNull(srvBidder);
        }

        #region Methods

        internal override Bidder GetSerchResult()
        {
            Bidder bidder = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int asesorId = Convert.ToInt32(activeRow.Cells[0].Value);
                bidder = this.srvBidder.LoadBidder(asesorId);
            }

            return bidder;
        }

        #endregion Methods
    }
}
