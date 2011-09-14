
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
    public partial class CustomerInfrastructureNetworkFirewallForm : CustomerInfrastructureNetworkFirewallSearchForm
    {
        #region Attributes

        private CustomerInfrastructureNetworkFirewallFormController ctrlCustomerInfrastructureNetworkFirewallForm;
        private ICustomerInfrastructureNetworkFirewallService srvCustomerInfrastructureNetworkFirewall;

        #endregion Attributes

        public CustomerInfrastructureNetworkFirewallForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureNetworkFirewallForm = new CustomerInfrastructureNetworkFirewallFormController(this);
            this.srvCustomerInfrastructureNetworkFirewall = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkFirewallService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkFirewall);
        }

        #region Methods

        public override CustomerInfrastructureNetworkFirewall GetSerchResult()
        {
            CustomerInfrastructureNetworkFirewall CustomerInfrastructureNetworkFirewall = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureNetworkFirewallId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureNetworkFirewall = this.srvCustomerInfrastructureNetworkFirewall.GetById(CustomerInfrastructureNetworkFirewallId);
            }

            return CustomerInfrastructureNetworkFirewall;
        }

        #endregion Methods
    }
}
