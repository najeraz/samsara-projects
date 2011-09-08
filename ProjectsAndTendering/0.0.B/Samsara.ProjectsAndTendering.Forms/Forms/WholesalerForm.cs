
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.Common.Context;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Core.Entities;
using Infragistics.Win.UltraWinGrid;
using System;

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

        internal override Wholesaler GetSerchResult()
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
