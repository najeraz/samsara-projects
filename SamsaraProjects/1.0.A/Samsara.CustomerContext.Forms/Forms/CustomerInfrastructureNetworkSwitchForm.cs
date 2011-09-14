
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
    public partial class CustomerInfrastructureNetworkSwitchForm : CustomerInfrastructureNetworkSwitchSearchForm
    {
        #region Attributes

        private CustomerInfrastructureNetworkSwitchFormController ctrlCustomerInfrastructureNetworkSwitchForm;
        private ICustomerInfrastructureNetworkSwitchService srvCustomerInfrastructureNetworkSwitch;

        #endregion Attributes

        public CustomerInfrastructureNetworkSwitchForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureNetworkSwitchForm = new CustomerInfrastructureNetworkSwitchFormController(this);
            this.srvCustomerInfrastructureNetworkSwitch = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkSwitchService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkSwitch);
        }

        #region Methods

        public override CustomerInfrastructureNetworkSwitch GetSerchResult()
        {
            CustomerInfrastructureNetworkSwitch CustomerInfrastructureNetworkSwitch = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureNetworkSwitchId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureNetworkSwitch = this.srvCustomerInfrastructureNetworkSwitch.GetById(CustomerInfrastructureNetworkSwitchId);
            }

            return CustomerInfrastructureNetworkSwitch;
        }

        #endregion Methods
    }
}
