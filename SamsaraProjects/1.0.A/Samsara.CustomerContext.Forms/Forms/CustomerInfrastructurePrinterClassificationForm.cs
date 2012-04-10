
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
    public partial class CustomerInfrastructurePrinterClassificationForm : CustomerInfrastructurePrinterClassificationSearchForm
    {
        #region Attributes

        private CustomerInfrastructurePrinterClassificationFormController ctrlCustomerInfrastructurePrinterClassificationForm;
        private ICustomerInfrastructurePrinterClassificationService srvCustomerInfrastructurePrinterClassification;

        #endregion Attributes

        public CustomerInfrastructurePrinterClassificationForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructurePrinterClassificationForm = new CustomerInfrastructurePrinterClassificationFormController(this);
            this.srvCustomerInfrastructurePrinterClassification = SamsaraAppContext.Resolve<ICustomerInfrastructurePrinterClassificationService>();
            Assert.IsNotNull(this.srvCustomerInfrastructurePrinterClassification);
        }

        #region Methods

        public override CustomerInfrastructurePrinterClassification GetSerchResult()
        {
            CustomerInfrastructurePrinterClassification CustomerInfrastructurePrinterClassification = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructurePrinterClassificationId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructurePrinterClassification = this.srvCustomerInfrastructurePrinterClassification.GetById(CustomerInfrastructurePrinterClassificationId);
            }

            return CustomerInfrastructurePrinterClassification;
        }

        #endregion Methods
    }
}
