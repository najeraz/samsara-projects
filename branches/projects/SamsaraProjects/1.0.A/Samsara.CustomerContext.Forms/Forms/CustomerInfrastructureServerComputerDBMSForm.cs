
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
    public partial class CustomerInfrastructureServerComputerDBMSForm : CustomerInfrastructureServerComputerDBMSSearchForm
    {
        #region Attributes

        private CustomerInfrastructureServerComputerDBMSFormController ctrlCustomerInfrastructureServerComputerDBMSForm;
        private ICustomerInfrastructureServerComputerDBMSService srvCustomerInfrastructureServerComputerDBMS;

        #endregion Attributes

        public CustomerInfrastructureServerComputerDBMSForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureServerComputerDBMSForm = new CustomerInfrastructureServerComputerDBMSFormController(this);
            this.srvCustomerInfrastructureServerComputerDBMS = SamsaraAppContext.Resolve<ICustomerInfrastructureServerComputerDBMSService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureServerComputerDBMS);
        }

        #region Methods

        public override CustomerInfrastructureServerComputerDBMS GetSerchResult()
        {
            CustomerInfrastructureServerComputerDBMS CustomerInfrastructureServerComputerDBMS = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureServerComputerDBMSId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureServerComputerDBMS = this.srvCustomerInfrastructureServerComputerDBMS.GetById(CustomerInfrastructureServerComputerDBMSId);
            }

            return CustomerInfrastructureServerComputerDBMS;
        }

        #endregion Methods
    }
}
