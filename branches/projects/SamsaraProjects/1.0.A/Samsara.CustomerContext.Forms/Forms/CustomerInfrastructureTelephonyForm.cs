
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
    public partial class CustomerInfrastructureTelephonyForm : CustomerInfrastructureTelephonySearchForm
    {
        #region Attributes

        private CustomerInfrastructureTelephonyFormController ctrlCustomerInfrastructureTelephonyForm;
        private ICustomerInfrastructureTelephonyService srvCustomerInfrastructureTelephony;

        #endregion Attributes

        public CustomerInfrastructureTelephonyForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureTelephonyForm = new CustomerInfrastructureTelephonyFormController(this);
            this.srvCustomerInfrastructureTelephony = SamsaraAppContext.Resolve<ICustomerInfrastructureTelephonyService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureTelephony);
        }

        #region Methods

        public override CustomerInfrastructureTelephony GetSerchResult()
        {
            CustomerInfrastructureTelephony CustomerInfrastructureTelephony = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureTelephonyId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureTelephony = this.srvCustomerInfrastructureTelephony.GetById(CustomerInfrastructureTelephonyId);
            }

            return CustomerInfrastructureTelephony;
        }

        #endregion Methods
    }
}
