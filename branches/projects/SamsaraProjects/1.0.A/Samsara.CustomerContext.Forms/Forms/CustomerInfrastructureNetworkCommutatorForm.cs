
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
    public partial class CustomerInfrastructureNetworkCommutatorForm : CustomerInfrastructureNetworkCommutatorSearchForm
    {
        #region Attributes

        private CustomerInfrastructureNetworkCommutatorFormController ctrlCustomerInfrastructureNetworkCommutatorForm;
        private ICustomerInfrastructureNetworkCommutatorService srvCustomerInfrastructureNetworkCommutator;

        #endregion Attributes

        public CustomerInfrastructureNetworkCommutatorForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureNetworkCommutatorForm = new CustomerInfrastructureNetworkCommutatorFormController(this);
            this.srvCustomerInfrastructureNetworkCommutator = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkCommutatorService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkCommutator);
        }

        #region Methods

        public override CustomerInfrastructureNetworkCommutator GetSerchResult()
        {
            CustomerInfrastructureNetworkCommutator CustomerInfrastructureNetworkCommutator = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureNetworkCommutatorId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureNetworkCommutator = this.srvCustomerInfrastructureNetworkCommutator.GetById(CustomerInfrastructureNetworkCommutatorId);
            }

            return CustomerInfrastructureNetworkCommutator;
        }

        #endregion Methods
    }
}
