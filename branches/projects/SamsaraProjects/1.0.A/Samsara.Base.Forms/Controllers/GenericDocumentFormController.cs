
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Forms.Enums;
using Samsara.Base.Forms.Forms;
using Samsara.Configuration.Core.Parameters;
using Samsara.Main.Session;

namespace Samsara.Base.Forms.Controllers
{
    public abstract class GenericDocumentFormController : SamsaraFormController
    {
        #region Attributes

        private GenericDocumentForm frmGenericDocument;
        private DataTable dtSearchGrid;
        protected FormStatusEnum formStatus;

        #endregion Attributes

        #region Properties
        #endregion Properties

        #region Constructor

        public GenericDocumentFormController(GenericDocumentForm frmGenericDocument)
            : base(frmGenericDocument)
        {
            FormConfigurationParameters pmtFormConfiguration = new FormConfigurationParameters();

            this.frmGenericDocument = frmGenericDocument;

            this.frmGenericDocument.grdPrincipal.InitializeLayout
                += new InitializeLayoutEventHandler(grdPrincipal_InitializeLayout);

            this.frmGenericDocument.ulblSchUsername.Text = Session.User.Username;

            this.formStatus = FormStatusEnum.Search;
            this.ShowDetail(false);
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected virtual void InitializeFormControls()
        {
            throw new NotImplementedException();
        }

        #endregion Protected

        #region Public

        public virtual void Search()
        {
            throw new NotImplementedException();
        }

        public virtual void ClearSearchFields()
        {
            throw new NotImplementedException();
        }

        public virtual void ReturnSelectedEntity()
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteEntity()
        {
            throw new NotImplementedException();
        }

        public virtual void CreateEntity()
        {
            throw new NotImplementedException();
        }

        public virtual void SaveEntity()
        {
            throw new NotImplementedException();
        }

        public virtual bool ValidateFormInformation()
        {
            throw new NotImplementedException();
        }

        public virtual void LoadDetail()
        {
            throw new NotImplementedException();
        }

        public virtual void ClearDetailFields()
        {
            throw new NotImplementedException();
        }

        public virtual void ReadOnlyDetailFields(bool readOnly)
        {
            throw new NotImplementedException();
        }

        public virtual bool LoadEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public virtual bool ConfirmDeleteEntity()
        {
            if (MessageBox.Show("¿Esta seguro de borrar el registro?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return false;

            return true;
        }

        public virtual void BackToSearch()
        {
            this.formStatus = FormStatusEnum.Search;
            this.ShowDetail(false);
        }

        #endregion Public

        #region Internal

        internal void CloseForm()
        {
            this.frmGenericDocument.Close();
        }

        internal void ShowDetailProcess()
        {
            UltraGridRow activeRow = this.frmGenericDocument.grdPrincipal.ActiveRow;

            if (activeRow != null && this.LoadEntity(Convert.ToInt32(activeRow.Cells[0].Value)))
            {
                this.ClearDetailFields();
                this.LoadDetail();
                this.ReadOnlyDetailFields(true);
                this.ShowDetail(true);
            }
        }

        internal void EditEntityProcess()
        {
            UltraGridRow activeRow = this.frmGenericDocument.grdPrincipal.ActiveRow;

            if (activeRow != null && this.LoadEntity(Convert.ToInt32(activeRow.Cells[0].Value)))
            {
                this.ClearDetailFields();
                this.LoadDetail();
                this.ReadOnlyDetailFields(false);
                this.ShowDetail(true);
            }
        }

        internal void DeleteEntityProcess()
        {
            UltraGridRow activeRow = this.frmGenericDocument.grdPrincipal.ActiveRow;

            if (activeRow != null && this.LoadEntity(Convert.ToInt32(activeRow.Cells[0].Value))
                && this.ConfirmDeleteEntity())
            {
                this.DeleteEntity();
            }
        }

        internal void CreateEntityProcess()
        {
            this.formStatus = FormStatusEnum.Creation;
            this.ClearDetailFields();
            this.ShowDetail(true);
            this.CreateEntity();
        }

        internal void SaveEntityProcess()
        {
            if (this.ValidateFormInformation())
            {
                this.SaveEntity();
                this.Search();
                this.BackToSearch();
            }
        }

        #endregion Internal

        #region Private

        private void ShowDetail(bool show)
        {
            this.frmGenericDocument.utcPrincipal.Tabs["tbSearch"].Visible = !show;
            this.frmGenericDocument.utcPrincipal.Tabs["tbDetail"].Visible = show;

            switch (this.formStatus)
            {
                case FormStatusEnum.Creation:
                    this.frmGenericDocument.utcPrincipal.Tabs["tbDetail"].Text = "Nuevo";
                    break;
                case FormStatusEnum.Edition:
                    this.frmGenericDocument.utcPrincipal.Tabs["tbDetail"].Text = "Edición";
                    break;
                default:
                    break;
            }
        }

        #endregion Private

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

                this.dtSearchGrid = this.frmGenericDocument.grdPrincipal.DataSource as DataTable;
            }
            else if (this.frmGenericDocument.grdPrincipal.DataSource != null
                && this.frmGenericDocument.grdPrincipal.DataSource is DataSet)
            {
                this.frmGenericDocument.ulblSchRowQuantity.Text
                    = (this.frmGenericDocument.grdPrincipal.DataSource as DataSet).Tables[0]
                    .Rows.Count.ToString();

                this.dtSearchGrid = (this.frmGenericDocument.grdPrincipal.DataSource as DataSet).Tables[0];
            }
        }

        #endregion Events
    }
}
