
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
    public partial class CustomerInfrastructureUPSForm : CustomerInfrastructureUPSSearchForm
    {
        #region Attributes

        private CustomerInfrastructureUPSFormController ctrlCustomerInfrastructureUPSForm;
        private ICustomerInfrastructureUPSService srvCustomerInfrastructureUPS;

        #endregion Attributes

        public CustomerInfrastructureUPSForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureUPSForm = new CustomerInfrastructureUPSFormController(this);
            this.srvCustomerInfrastructureUPS = SamsaraAppContext.Resolve<ICustomerInfrastructureUPSService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureUPS);
        }

        #region Methods

        public override CustomerInfrastructureUPS GetSerchResult()
        {
            CustomerInfrastructureUPS CustomerInfrastructureUPS = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureUPSId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureUPS = this.srvCustomerInfrastructureUPS.GetById(CustomerInfrastructureUPSId);
            }

            return CustomerInfrastructureUPS;
        }

        #endregion Methods
    }
}
