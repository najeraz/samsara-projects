
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
    public partial class CustomerInfrastructurePrinterForm : CustomerInfrastructurePrinterSearchForm
    {
        #region Attributes

        private CustomerInfrastructurePrinterFormController ctrlCustomerInfrastructurePrinterForm;
        private ICustomerInfrastructurePrinterService srvCustomerInfrastructurePrinter;

        #endregion Attributes

        public CustomerInfrastructurePrinterForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructurePrinterForm = new CustomerInfrastructurePrinterFormController(this);
            this.srvCustomerInfrastructurePrinter = SamsaraAppContext.Resolve<ICustomerInfrastructurePrinterService>();
            Assert.IsNotNull(this.srvCustomerInfrastructurePrinter);
        }

        #region Methods

        public override CustomerInfrastructurePrinter GetSerchResult()
        {
            CustomerInfrastructurePrinter CustomerInfrastructurePrinter = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructurePrinterId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructurePrinter = this.srvCustomerInfrastructurePrinter.GetById(CustomerInfrastructurePrinterId);
            }

            return CustomerInfrastructurePrinter;
        }

        #endregion Methods
    }
}
