
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
    public partial class CustomerInfrastructureServerComputerForm : CustomerInfrastructureServerComputerSearchForm
    {
        #region Attributes

        private CustomerInfrastructureServerComputerFormController ctrlCustomerInfrastructureServerComputerForm;
        private ICustomerInfrastructureServerComputerService srvCustomerInfrastructureServerComputer;

        #endregion Attributes

        public CustomerInfrastructureServerComputerForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureServerComputerForm = new CustomerInfrastructureServerComputerFormController(this);
            this.srvCustomerInfrastructureServerComputer = SamsaraAppContext.Resolve<ICustomerInfrastructureServerComputerService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureServerComputer);
        }

        #region Methods

        public override CustomerInfrastructureServerComputer GetSerchResult()
        {
            CustomerInfrastructureServerComputer CustomerInfrastructureServerComputer = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureServerComputerId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureServerComputer = this.srvCustomerInfrastructureServerComputer.GetById(CustomerInfrastructureServerComputerId);
            }

            return CustomerInfrastructureServerComputer;
        }

        #endregion Methods
    }
}
