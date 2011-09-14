
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
    public partial class CustomerInfrastructureNetworkRouterForm : CustomerInfrastructureNetworkRouterSearchForm
    {
        #region Attributes

        private CustomerInfrastructureNetworkRouterFormController ctrlCustomerInfrastructureNetworkRouterForm;
        private ICustomerInfrastructureNetworkRouterService srvCustomerInfrastructureNetworkRouter;

        #endregion Attributes

        public CustomerInfrastructureNetworkRouterForm()
        {
            InitializeComponent();
            this.ctrlCustomerInfrastructureNetworkRouterForm = new CustomerInfrastructureNetworkRouterFormController(this);
            this.srvCustomerInfrastructureNetworkRouter = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkRouterService>();
            Assert.IsNotNull(this.srvCustomerInfrastructureNetworkRouter);
        }

        #region Methods

        public override CustomerInfrastructureNetworkRouter GetSerchResult()
        {
            CustomerInfrastructureNetworkRouter CustomerInfrastructureNetworkRouter = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int CustomerInfrastructureNetworkRouterId = Convert.ToInt32(activeRow.Cells[0].Value);
                CustomerInfrastructureNetworkRouter = this.srvCustomerInfrastructureNetworkRouter.GetById(CustomerInfrastructureNetworkRouterId);
            }

            return CustomerInfrastructureNetworkRouter;
        }

        #endregion Methods
    }
}
