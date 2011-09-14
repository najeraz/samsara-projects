
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
    public partial class CustomerInfrastructureNetworkSiteForm : CustomerInfrastructureNetworkSiteSearchForm
    {
        #region Attributes

        private CustomerInfrastructureNetworkSiteFormController ctrlCustomerInfrastructureNetworkSiteForm;
        private ICustomerInfrastructureNetworkSiteService srvCustomerInfrastructureNetworkSite;

        #endregion Attributes

        public CustomerInfrastructureNetworkSiteForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureNetworkSiteForm = new CustomerInfrastructureNetworkSiteFormController(this);
            this.srvCustomerInfrastructureNetworkSite = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkSiteService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkSite);
        }

        #region Methods

        public override CustomerInfrastructureNetworkSite GetSerchResult()
        {
            CustomerInfrastructureNetworkSite CustomerInfrastructureNetworkSite = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureNetworkSiteId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureNetworkSite = this.srvCustomerInfrastructureNetworkSite.GetById(CustomerInfrastructureNetworkSiteId);
            }

            return CustomerInfrastructureNetworkSite;
        }

        #endregion Methods
    }
}
