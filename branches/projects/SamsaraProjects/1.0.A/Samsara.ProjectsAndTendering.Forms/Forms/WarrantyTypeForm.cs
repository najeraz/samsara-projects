
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
    public partial class WarrantyTypeForm : WarrantyTypeSearchForm
    {
        #region Attributes

        private WarrantyTypeFormController ctrlWarrantyTypeForm;
        private IWarrantyTypeService srvWarrantyType;

        #endregion Attributes

        public WarrantyTypeForm()
        {
            InitializeComponent();
            this.ctrlWarrantyTypeForm = new WarrantyTypeFormController(this);
            this.srvWarrantyType = SamsaraAppContext.Resolve<IWarrantyTypeService>();
            Assert.IsNotNull(this.srvWarrantyType);
        }

        #region Methods

        public override WarrantyType GetSerchResult()
        {
            WarrantyType WarrantyType = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int WarrantyTypeId = Convert.ToInt32(activeRow.Cells[0].Value);
                WarrantyType = this.srvWarrantyType.GetById(WarrantyTypeId);
            }

            return WarrantyType;
        }

        #endregion Methods
    }
}
