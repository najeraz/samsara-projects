
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Forms.Enums;
using Samsara.Base.Forms.Forms;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Main.Session;

namespace Samsara.Base.Forms.Controllers
{
    public abstract class GenericDocumentFormController : SamsaraFormController
    {
        #region Attributes

        private GenericDocumentForm frmGenericDocument;
        private DataTable dtSearchGrid;

        #endregion Attributes

        #region Properties

        protected FormStatusEnum FormStatus
        {
            get;
            set;
        }

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

            if (this.FormConfiguration != null)
                this.frmGenericDocument.Text = this.FormConfiguration.FormEndUserName;

            this.FormStatus = FormStatusEnum.Search;
            this.ShowDetail(false);
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected virtual void ReadOnlySearchFields(bool readOnly)
        {
            this.frmGenericDocument.btnDetCancel.Enabled = !readOnly;
            this.frmGenericDocument.btnDetSave.Enabled = !readOnly;
            this.frmGenericDocument.btnSchAccept.Enabled = !readOnly;
            this.frmGenericDocument.btnSchClear.Enabled = !readOnly;
            this.frmGenericDocument.btnSchClose.Enabled = !readOnly;
            this.frmGenericDocument.btnSchCreate.Enabled = !readOnly;
            this.frmGenericDocument.btnSchDelete.Enabled = !readOnly;
            this.frmGenericDocument.btnSchEdit.Enabled = !readOnly;
            this.frmGenericDocument.btnSchSearch.Enabled = !readOnly;
            this.frmGenericDocument.btnSchShowDetail.Enabled = !readOnly;
        }

        protected bool HasPermission(Enum permission)
        {
            FormConfigurationUserPermissionUser formConfigurationUserPermissionUser
                = this.FormConfiguration.FormConfigurationUserPermissions
                .SelectMany(x => x.FormConfigurationUserPermissionUsers).SingleOrDefault(x =>
                    x.FormConfigurationUserPermission.UserPermissionId == Convert.ToInt32(permission) &&
                x.User.UserId == Session.User.UserId);

            return formConfigurationUserPermissionUser != null;
        }

        protected virtual void ShowDetail(bool show)
        {
            this.frmGenericDocument.utcPrincipal.Tabs["tbSearch"].Visible = !show;
            this.frmGenericDocument.utcPrincipal.Tabs["tbDetail"].Visible = show;

            switch (this.FormStatus)
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

        #endregion Protected

        #region Public

        public virtual bool ValidateCanEditEntity()
        {
            return true;
        }

        public virtual bool ValidateCanDeleteEntity()
        {
            return true;
        }

        public virtual bool ValidateCanCreateEntity()
        {
            return true;
        }

        public virtual bool ValidateCanSaveEntity()
        {
            return true;
        }

        public virtual bool ValidateCanShowDetail()
        {
            return true;
        }

        public abstract void Search();

        public abstract void InitializeDetailFormControls();

        public abstract void ClearSearchFields();

        public abstract void ReturnSelectedEntity();

        public abstract void DeleteEntity();

        public abstract void CreateEntity();

        public abstract void SaveEntity();

        public abstract bool ValidateFormInformation();

        public abstract void LoadDetail();

        public abstract void ClearDetailFields();

        public abstract void ReadOnlyDetailFields(bool readOnly);

        public abstract bool LoadEntity(int entityId);

        public virtual bool ConfirmDeleteEntity()
        {
            if (MessageBox.Show("¿Esta seguro de borrar el registro?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return false;

            return true;
        }

        public virtual void BackToSearch()
        {
            this.FormStatus = FormStatusEnum.Search;
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

            if (activeRow != null && this.ValidateCanShowDetail()
                && this.LoadEntity(Convert.ToInt32(activeRow.Cells[0].Value)))
            {
                this.FormStatus = FormStatusEnum.ShowDetail;
                this.InitializeDetailFormControls();
                this.ClearDetailFields();
                this.LoadDetail();
                this.ProcessDetailButtons();
                this.ReadOnlyDetailFields(true);
                this.ShowDetail(true);
            }
        }

        internal void EditEntityProcess()
        {
            UltraGridRow activeRow = this.frmGenericDocument.grdPrincipal.ActiveRow;

            if (activeRow != null && this.ValidateCanEditEntity() 
                && this.LoadEntity(Convert.ToInt32(activeRow.Cells[0].Value)))
            {
                this.FormStatus = FormStatusEnum.Edition;
                this.InitializeDetailFormControls();
                this.ClearDetailFields();
                this.ReadOnlyDetailFields(false);
                this.LoadDetail();
                this.ProcessDetailButtons();
                this.ShowDetail(true);
            }
        }

        internal void DeleteEntityProcess()
        {
            UltraGridRow activeRow = this.frmGenericDocument.grdPrincipal.ActiveRow;

            if (activeRow != null && this.ValidateCanDeleteEntity()
                && this.LoadEntity(Convert.ToInt32(activeRow.Cells[0].Value))
                && this.ConfirmDeleteEntity())
            {
                this.DeleteEntity();
            }
        }

        internal void CreateEntityProcess()
        {
            if (this.ValidateCanCreateEntity())
            {
                this.FormStatus = FormStatusEnum.Creation;
                this.InitializeDetailFormControls();
                this.ClearDetailFields();
                this.ProcessDetailButtons();
                this.ReadOnlyDetailFields(false);
                this.ShowDetail(true);
                this.CreateEntity();
            }
        }

        internal void SaveEntityProcess()
        {
            if (this.ValidateCanSaveEntity() && this.ValidateFormInformation())
            {
                this.SaveEntity();
                this.Search();
                this.BackToSearch();
            }
        }

        #endregion Internal

        #region Private

        private void ProcessDetailButtons()
        {
            switch (this.FormStatus)
            {
                case FormStatusEnum.Creation:
                case FormStatusEnum.Edition:
                    this.frmGenericDocument.btnDetSave.Visible = true;
                    this.frmGenericDocument.upDetSeparatorBtnSave.Visible = true;
                    this.frmGenericDocument.btnDetCancel.Visible = true;
                    this.frmGenericDocument.upDetSeparatorBtnCancel.Visible = true;
                    this.frmGenericDocument.btnDetBackToSearch.Visible = false;
                    this.frmGenericDocument.upDetSeparatorBtnBackToSearch.Visible = false;
                    break;
                case FormStatusEnum.ShowDetail:
                    this.frmGenericDocument.btnDetSave.Visible = false;
                    this.frmGenericDocument.upDetSeparatorBtnSave.Visible = false;
                    this.frmGenericDocument.upDetSeparatorBtnCancel.Visible = false;
                    this.frmGenericDocument.btnDetCancel.Visible = false;
                    this.frmGenericDocument.btnDetBackToSearch.Visible = true;
                    this.frmGenericDocument.upDetSeparatorBtnBackToSearch.Visible = true;
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
