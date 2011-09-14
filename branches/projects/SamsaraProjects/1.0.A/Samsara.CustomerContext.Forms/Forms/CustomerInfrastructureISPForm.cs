
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
    public partial class CustomerInfrastructureISPForm : CustomerInfrastructureISPSearchForm
    {
        #region Attributes

        private CustomerInfrastructureISPFormController ctrlCustomerInfrastructureISPForm;
        private ICustomerInfrastructureISPService srvCustomerInfrastructureISP;

        #endregion Attributes

        public CustomerInfrastructureISPForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureISPForm = new CustomerInfrastructureISPFormController(this);
            this.srvCustomerInfrastructureISP = SamsaraAppContext.Resolve<ICustomerInfrastructureISPService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureISP);
        }

        #region Methods

        public override CustomerInfrastructureISP GetSerchResult()
        {
            CustomerInfrastructureISP CustomerInfrastructureISP = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureISPId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureISP = this.srvCustomerInfrastructureISP.GetById(CustomerInfrastructureISPId);
            }

            return CustomerInfrastructureISP;
        }

        #endregion Methods
    }
}
