
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
    public partial class CustomerInfrastructureNetworkWifiAccessPointForm : CustomerInfrastructureNetworkWifiAccessPointSearchForm
    {
        #region Attributes

        private CustomerInfrastructureNetworkWifiAccessPointFormController ctrlCustomerInfrastructureNetworkWifiAccessPointForm;
        private ICustomerInfrastructureNetworkWifiAccessPointService srvCustomerInfrastructureNetworkWifiAccessPoint;

        #endregion Attributes

        public CustomerInfrastructureNetworkWifiAccessPointForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureNetworkWifiAccessPointForm = new CustomerInfrastructureNetworkWifiAccessPointFormController(this);
            this.srvCustomerInfrastructureNetworkWifiAccessPoint = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkWifiAccessPointService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkWifiAccessPoint);
        }

        #region Methods

        public override CustomerInfrastructureNetworkWifiAccessPoint GetSerchResult()
        {
            CustomerInfrastructureNetworkWifiAccessPoint CustomerInfrastructureNetworkWifiAccessPoint = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureNetworkWifiAccessPointId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureNetworkWifiAccessPoint = this.srvCustomerInfrastructureNetworkWifiAccessPoint.GetById(CustomerInfrastructureNetworkWifiAccessPointId);
            }

            return CustomerInfrastructureNetworkWifiAccessPoint;
        }

        #endregion Methods
    }
}
