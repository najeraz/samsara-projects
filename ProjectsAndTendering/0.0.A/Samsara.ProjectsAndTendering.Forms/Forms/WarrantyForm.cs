
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Common;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Infragistics.Win.UltraWinGrid;
using System;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class WarrantyForm : WarrantySearchForm
    {
        #region Attributes

        private WarrantyFormController ctrlWarrantyForm;
        private IWarrantyService srvWarranty;

        #endregion Attributes

        public WarrantyForm()
        {
            InitializeComponent();
            this.ctrlWarrantyForm = new WarrantyFormController(this);
            this.srvWarranty = SamsaraAppContext.Resolve<IWarrantyService>();
            Assert.IsNotNull(this.srvWarranty);
        }

        #region Methods

        internal override Warranty GetSerchResult()
        {
            Warranty Warranty = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int WarrantyId = Convert.ToInt32(activeRow.Cells[0].Value);
                Warranty = this.srvWarranty.GetById(WarrantyId);
            }

            return Warranty;
        }

        #endregion Methods
    }
}
