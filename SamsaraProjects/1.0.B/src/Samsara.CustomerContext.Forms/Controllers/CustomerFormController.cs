
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Controls.EventsArgs;
using Samsara.Base.Controls.EventsHandlers;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Controllers;
using Samsara.Base.Forms.Enums;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Enums;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.Framework.Core.Entities;
using Samsara.Framework.Core.Enums;
using Samsara.Framework.Service.Interfaces;
using Samsara.Framework.Util;
using Samsara.CustomerContext.Forms.Forms;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Controllers
{
    public class CustomerFormController : GenericDocumentFormController
    {
        #region Attributes

        private CustomerForm frmCustomer;
        private ICustomerService srvCustomer;
        private Customer customer;

        #endregion Attributes

        #region Properties

        #endregion Properties

        #region Constructor

        public CustomerFormController(CustomerForm frmCustomer)
            : base(frmCustomer)
        {
            this.frmCustomer = frmCustomer;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomer = SamsaraAppContext.Resolve<ICustomerService>();
            }
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected override void ReadOnlySearchFields(bool readOnly)
        {
            base.ReadOnlySearchFields(readOnly);
        }

        protected override void ShowDetail(bool show)
        {
            base.ShowDetail(show);

            if (show)
            {
                switch (this.FormStatus)
                {
                    case FormStatusEnum.Creation:
                    case FormStatusEnum.Edition:
                        break;
                    case FormStatusEnum.ShowDetail:
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion Protected

        #region Public

        public override void InitializeFormControls()
        {
        }

        public override void InitializeDetailFormControls()
        {
        }

        public override void Search()
        {
            CustomerParameters pmtCustomer = new CustomerParameters();

            this.frmCustomer.grdPrincipal.DataSource = null;
            this.frmCustomer.grdPrincipal.DataSource = this.srvCustomer.SearchByParameters(pmtCustomer);
        }

        public override void ClearSearchFields()
        {
            this.frmCustomer.txtSchOrganizationName.Value = null;
            this.frmCustomer.txtSchContact.Value = null;
        }

        public override void ReturnSelectedEntity()
        {
        }

        public override void DeleteEntity()
        {
            //if (serverConsulting != null)
            //{
            //    this.srvCustomer.Delete(serverConsulting);
            //}

            this.Search();
        }

        public override bool ValidateFormInformation()
        {

            return true;
        }

        public override bool LoadEntity(int serverConsultingId)
        {
            this.customer = this.srvCustomer.GetById(serverConsultingId);

            return this.customer != null;
        }

        public override void CreateEntity()
        {
            this.customer = new Customer();
        }

        public override void ReadOnlyDetailFields(bool readOnly)
        {
        }

        public override void LoadDetail()
        {
        }

        public override void SaveEntity()
        {
            //this.srvCustomer.SaveOrUpdate(this.serverConsulting);
        }

        public override void ClearDetailFields()
        {
        }

        #endregion Public

        #region Private

        #endregion Private

        #region Internal

        #endregion Internal

        #endregion Methods

        #region Events

        #endregion Events
    }
}
