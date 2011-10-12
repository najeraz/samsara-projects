
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
    public partial class WholesalerForm : WholesalerSearchForm
    {
        #region Attributes

        private WholesalerFormController ctrlWholesalerForm;
        private IWholesalerService srvWholesaler;

        #endregion Attributes

        public WholesalerForm()
        {
            InitializeComponent();
            this.ctrlWholesalerForm = new WholesalerFormController(this);
            this.srvWholesaler = SamsaraAppContext.Resolve<IWholesalerService>();
            Assert.IsNotNull(this.srvWholesaler);
        }

        #region Methods

        public override Wholesaler GetSearchResult()
        {
            Wholesaler Wholesaler = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int WholesalerId = Convert.ToInt32(activeRow.Cells[0].Value);
                Wholesaler = this.srvWholesaler.GetById(WholesalerId);
            }

            return Wholesaler;
        }

        #endregion Methods
    }
}
