
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
    public partial class CustomerInfrastructureCCTVForm : CustomerInfrastructureCCTVSearchForm
    {
        #region Attributes

        private CustomerInfrastructureCCTVFormController ctrlCustomerInfrastructureCCTVForm;
        private ICustomerInfrastructureCCTVService srvCustomerInfrastructureCCTV;

        #endregion Attributes

        public CustomerInfrastructureCCTVForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureCCTVForm = new CustomerInfrastructureCCTVFormController(this);
            this.srvCustomerInfrastructureCCTV = SamsaraAppContext.Resolve<ICustomerInfrastructureCCTVService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureCCTV);
        }

        #region Methods

        public override CustomerInfrastructureCCTV GetSerchResult()
        {
            CustomerInfrastructureCCTV CustomerInfrastructureCCTV = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureCCTVId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureCCTV = this.srvCustomerInfrastructureCCTV.GetById(CustomerInfrastructureCCTVId);
            }

            return CustomerInfrastructureCCTV;
        }

        #endregion Methods
    }
}
