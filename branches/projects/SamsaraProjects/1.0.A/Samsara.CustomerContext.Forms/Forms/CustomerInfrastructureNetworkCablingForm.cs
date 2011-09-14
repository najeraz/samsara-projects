
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
    public partial class CustomerInfrastructureNetworkCablingForm : CustomerInfrastructureNetworkCablingSearchForm
    {
        #region Attributes

        private CustomerInfrastructureNetworkCablingFormController ctrlCustomerInfrastructureNetworkCablingForm;
        private ICustomerInfrastructureNetworkCablingService srvCustomerInfrastructureNetworkCabling;

        #endregion Attributes

        public CustomerInfrastructureNetworkCablingForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureNetworkCablingForm = new CustomerInfrastructureNetworkCablingFormController(this);
            this.srvCustomerInfrastructureNetworkCabling = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkCablingService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkCabling);
        }

        #region Methods

        public override CustomerInfrastructureNetworkCabling GetSerchResult()
        {
            CustomerInfrastructureNetworkCabling CustomerInfrastructureNetworkCabling = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureNetworkCablingId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureNetworkCabling = this.srvCustomerInfrastructureNetworkCabling.GetById(CustomerInfrastructureNetworkCablingId);
            }

            return CustomerInfrastructureNetworkCabling;
        }

        #endregion Methods
    }
}
