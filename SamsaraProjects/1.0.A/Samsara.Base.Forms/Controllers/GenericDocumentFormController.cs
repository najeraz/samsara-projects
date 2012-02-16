﻿
using System.ComponentModel;
using System.Data;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Forms;
using Samsara.Main.Session;
using System.Diagnostics;

namespace Samsara.Base.Forms.Controllers
{
    public class GenericDocumentFormController
    {
        #region Attributes

        private GenericDocumentForm frmGenericDocument;
        protected IAlleatoERPService srvAlleatoERP;

        #endregion Attributes

        #region Constructor

        public GenericDocumentFormController(GenericDocumentForm frmGenericDocument)
        {
            this.frmGenericDocument = frmGenericDocument;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvAlleatoERP = SamsaraAppContext.Resolve<IAlleatoERPService>();
                Assert.IsNotNull(this.srvAlleatoERP);
            }

            this.frmGenericDocument.grdPrincipal.InitializeLayout
                += new InitializeLayoutEventHandler(grdPrincipal_InitializeLayout);

            this.frmGenericDocument.ulblSchUsername.Text = Session.User.Username;
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected virtual void InitializeFormControls()
        {
            this.ClearPrincipalControls();
        }

        protected virtual void ClearPrincipalControls()
        {
        }

        #endregion Protected

        #region Public

        internal virtual void Search()
        {
        }

        internal virtual void ClearSearchFields()
        {
        }

        internal virtual void ReturnSelectedEntity()
        {
        }

        internal virtual void CloseForm()
        {
        }

        internal virtual void DeleteSelectedEntity()
        {
        }

        internal virtual void EditSelectedEntity()
        {
        }

        internal virtual void CreateEntity()
        {
        }

        internal virtual void CancelSaveOrUpdate()
        {
        }

        internal virtual void SaveEntity()
        {
        }

        #endregion Public

        #endregion Methods

        #region Events

        [DebuggerStepThrough]
        private void grdPrincipal_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            if (this.frmGenericDocument.grdPrincipal.DataSource != null
                && this.frmGenericDocument.grdPrincipal.DataSource is DataTable)
            {
                this.frmGenericDocument.ulblSchRowQuantity.Text
                    = (this.frmGenericDocument.grdPrincipal.DataSource as DataTable)
                    .Rows.Count.ToString();
            }
            else if (this.frmGenericDocument.grdPrincipal.DataSource != null
                && this.frmGenericDocument.grdPrincipal.DataSource is DataSet)
            {
                this.frmGenericDocument.ulblSchRowQuantity.Text
                    = (this.frmGenericDocument.grdPrincipal.DataSource as DataSet).Tables[0]
                    .Rows.Count.ToString();
            }
        }

        #endregion Events
    }
}
