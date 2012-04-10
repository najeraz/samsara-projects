
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class FirewallBrandForm : FirewallBrandSearchForm
    {
        #region Attributes

        private FirewallBrandFormController ctrlFirewallBrandForm;
        private IFirewallBrandService srvFirewallBrand;

        #endregion Attributes

        public FirewallBrandForm()
        {
            InitializeComponent();
            this.ctrlFirewallBrandForm = new FirewallBrandFormController(this);
            this.srvFirewallBrand = SamsaraAppContext.Resolve<IFirewallBrandService>();
        }

        #region Methods

        public override FirewallBrand GetSearchResult()
        {
            FirewallBrand FirewallBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int FirewallBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                FirewallBrand = this.srvFirewallBrand.GetById(FirewallBrandId);
            }

            return FirewallBrand;
        }

        #endregion Methods
    }
}
