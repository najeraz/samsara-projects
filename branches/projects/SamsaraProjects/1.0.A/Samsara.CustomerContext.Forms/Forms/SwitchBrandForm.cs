
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
    public partial class SwitchBrandForm : SwitchBrandSearchForm
    {
        #region Attributes

        private SwitchBrandFormController ctrlSwitchBrandForm;
        private ISwitchBrandService srvSwitchBrand;

        #endregion Attributes

        public SwitchBrandForm()
        {
            InitializeComponent();
            this.ctrlSwitchBrandForm = new SwitchBrandFormController(this);
            this.srvSwitchBrand = SamsaraAppContext.Resolve<ISwitchBrandService>();
            Assert.IsNotNull(this.srvSwitchBrand);
        }

        #region Methods

        public override SwitchBrand GetSearchResult()
        {
            SwitchBrand SwitchBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int SwitchBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                SwitchBrand = this.srvSwitchBrand.GetById(SwitchBrandId);
            }

            return SwitchBrand;
        }

        #endregion Methods
    }
}
