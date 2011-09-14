
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
    public partial class CustomerInfrastructurePersonalComputerForm : CustomerInfrastructurePersonalComputerSearchForm
    {
        #region Attributes

        private CustomerInfrastructurePersonalComputerFormController ctrlCustomerInfrastructurePersonalComputerForm;
        private ICustomerInfrastructurePersonalComputerService srvCustomerInfrastructurePersonalComputer;

        #endregion Attributes

        public CustomerInfrastructurePersonalComputerForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructurePersonalComputerForm = new CustomerInfrastructurePersonalComputerFormController(this);
            this.srvCustomerInfrastructurePersonalComputer = SamsaraAppContext.Resolve<ICustomerInfrastructurePersonalComputerService>();
            Assert.IsNotNull(this.srvCustomerInfrastructurePersonalComputer);
        }

        #region Methods

        public override CustomerInfrastructurePersonalComputer GetSerchResult()
        {
            CustomerInfrastructurePersonalComputer CustomerInfrastructurePersonalComputer = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructurePersonalComputerId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructurePersonalComputer = this.srvCustomerInfrastructurePersonalComputer.GetById(CustomerInfrastructurePersonalComputerId);
            }

            return CustomerInfrastructurePersonalComputer;
        }

        #endregion Methods
    }
}
