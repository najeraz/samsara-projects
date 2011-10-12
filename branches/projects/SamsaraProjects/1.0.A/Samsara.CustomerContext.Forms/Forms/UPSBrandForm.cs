
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
    public partial class UPSBrandForm : UPSBrandSearchForm
    {
        #region Attributes

        private UPSBrandFormController ctrlUPSBrandForm;
        private IUPSBrandService srvUPSBrand;

        #endregion Attributes

        public UPSBrandForm()
        {
            InitializeComponent();
            this.ctrlUPSBrandForm = new UPSBrandFormController(this);
            this.srvUPSBrand = SamsaraAppContext.Resolve<IUPSBrandService>();
            Assert.IsNotNull(this.srvUPSBrand);
        }

        #region Methods

        public override UPSBrand GetSearchResult()
        {
            UPSBrand UPSBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int UPSBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                UPSBrand = this.srvUPSBrand.GetById(UPSBrandId);
            }

            return UPSBrand;
        }

        #endregion Methods
    }
}
