
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
    public partial class CustomerInfrastructureForm : CustomerInfrastructureSearchForm
    {
        #region Attributes

        private CustomerInfrastructureFormController ctrlCustomerInfrastructureForm;
        private ICustomerInfrastructureService srvCustomerInfrastructure;

        #endregion Attributes

        public CustomerInfrastructureForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureForm = new CustomerInfrastructureFormController(this);
            this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
            Assert.IsNotNull(this.srvCustomerInfrastructure);
        }

        #region Methods

        public override CustomerInfrastructure GetSerchResult()
        {
            CustomerInfrastructure CustomerInfrastructure = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructure = this.srvCustomerInfrastructure.GetById(CustomerInfrastructureId);
            }

            return CustomerInfrastructure;
        }

        #endregion Methods
    }
}
