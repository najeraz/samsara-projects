
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class AccessPointBrandForm : AccessPointBrandSearchForm
    {
        #region Attributes

        private AccessPointBrandFormController ctrlAccessPointBrandForm;
        private IAccessPointBrandService srvAccessPointBrand;

        #endregion Attributes

        public AccessPointBrandForm()
        {
            InitializeComponent();
            this.ctrlAccessPointBrandForm = new AccessPointBrandFormController(this);
            this.srvAccessPointBrand = SamsaraAppContext.Resolve<IAccessPointBrandService>();
            Assert.IsNotNull(this.srvAccessPointBrand);
        }

        #region Methods

        public override AccessPointBrand GetSearchResult()
        {
            AccessPointBrand AccessPointBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int AccessPointBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                AccessPointBrand = this.srvAccessPointBrand.GetById(AccessPointBrandId);
            }

            return AccessPointBrand;
        }

        #endregion Methods
    }
}
