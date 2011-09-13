
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces;

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
            Assert.IsNotNull(this.srvBidder);
        }

        #region Methods

        public override Bidder GetSerchResult()
        {
            Bidder bidder = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int asesorId = Convert.ToInt32(activeRow.Cells[0].Value);
                bidder = this.srvBidder.GetById(asesorId);
            }

            return bidder;
        }

        #endregion Methods
    }
}
