
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
    public partial class CustomerInfrastructureNetworkWifiForm : CustomerInfrastructureNetworkWifiSearchForm
    {
        #region Attributes

        private CustomerInfrastructureNetworkWifiFormController ctrlCustomerInfrastructureNetworkWifiForm;
        private ICustomerInfrastructureNetworkWifiService srvCustomerInfrastructureNetworkWifi;

        #endregion Attributes

        public CustomerInfrastructureNetworkWifiForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureNetworkWifiForm = new CustomerInfrastructureNetworkWifiFormController(this);
            this.srvCustomerInfrastructureNetworkWifi = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkWifiService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkWifi);
        }

        #region Methods

        public override CustomerInfrastructureNetworkWifi GetSerchResult()
        {
            CustomerInfrastructureNetworkWifi CustomerInfrastructureNetworkWifi = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureNetworkWifiId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureNetworkWifi = this.srvCustomerInfrastructureNetworkWifi.GetById(CustomerInfrastructureNetworkWifiId);
            }

            return CustomerInfrastructureNetworkWifi;
        }

        #endregion Methods
    }
}
