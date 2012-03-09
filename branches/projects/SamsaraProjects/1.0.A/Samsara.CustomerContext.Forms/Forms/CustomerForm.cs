
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class CustomerForm : CustomerSearchForm
    {
        #region Attributes

        private CustomerFormController ctrlCustomerForm;
        private ICustomerService srvCustomer;

        #endregion Attributes

        public CustomerForm()
        {
            InitializeComponent();
            this.ctrlCustomerForm = new CustomerFormController(this);
            this.srvCustomer = SamsaraAppContext.Resolve<ICustomerService>();
        }

        #region Methods

        public override Customer GetSearchResult()
        {
            Customer Customer = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerId = Convert.ToInt32(activeRow.Cells[0].Value);
                Customer = this.srvCustomer.GetById(CustomerId);
            }

            return Customer;
        }

        #endregion Methods
    }
}
