
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
    public partial class CustomerInfrastructureNetworkSiteRackForm : CustomerInfrastructureNetworkSiteRackSearchForm
    {
        #region Attributes

        private CustomerInfrastructureNetworkSiteRackFormController ctrlCustomerInfrastructureNetworkSiteRackForm;
        private ICustomerInfrastructureNetworkSiteRackService srvCustomerInfrastructureNetworkSiteRack;

        #endregion Attributes

        public CustomerInfrastructureNetworkSiteRackForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureNetworkSiteRackForm = new CustomerInfrastructureNetworkSiteRackFormController(this);
            this.srvCustomerInfrastructureNetworkSiteRack = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkSiteRackService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkSiteRack);
        }

        #region Methods

        public override CustomerInfrastructureNetworkSiteRack GetSerchResult()
        {
            CustomerInfrastructureNetworkSiteRack CustomerInfrastructureNetworkSiteRack = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureNetworkSiteRackId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureNetworkSiteRack = this.srvCustomerInfrastructureNetworkSiteRack.GetById(CustomerInfrastructureNetworkSiteRackId);
            }

            return CustomerInfrastructureNetworkSiteRack;
        }

        #endregion Methods
    }
}
