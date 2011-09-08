
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.Common;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Core.Entities;
using Infragistics.Win.UltraWinGrid;
using System;

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

        internal override WarrantyType GetSerchResult()
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
