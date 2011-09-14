
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
    public partial class CustomerInfrastructureNetworkForm : CustomerInfrastructureNetworkSearchForm
    {
        #region Attributes

        private CustomerInfrastructureNetworkFormController ctrlCustomerInfrastructureNetworkForm;
        private ICustomerInfrastructureNetworkService srvCustomerInfrastructureNetwork;

        #endregion Attributes

        public CustomerInfrastructureNetworkForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureNetworkForm = new CustomerInfrastructureNetworkFormController(this);
            this.srvCustomerInfrastructureNetwork = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetwork);
        }

        #region Methods

        public override CustomerInfrastructureNetwork GetSerchResult()
        {
            CustomerInfrastructureNetwork CustomerInfrastructureNetwork = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureNetworkId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureNetwork = this.srvCustomerInfrastructureNetwork.GetById(CustomerInfrastructureNetworkId);
            }

            return CustomerInfrastructureNetwork;
        }

        #endregion Methods
    }
}
