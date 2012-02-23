
using System.Data;
using System.Diagnostics;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Forms.Forms;
using Samsara.Main.Session;

namespace Samsara.Base.Forms.Controllers
{
    public class GenericDocumentFormController
    {
        #region Attributes

        private GenericDocumentForm frmGenericDocument;
        private DataTable dtSearchGrid;

        #endregion Attributes

        #region Constructor

        public GenericDocumentFormController(GenericDocumentForm frmGenericDocument)
        {
            this.frmGenericDocument = frmGenericDocument;

            this.frmGenericDocument.grdPrincipal.InitializeLayout
                += new InitializeLayoutEventHandler(grdPrincipal_InitializeLayout);

            this.frmGenericDocument.ulblSchUsername.Text = Session.User.Username;

            //this.InitializeFormControls();
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected virtual void InitializeFormControls()
        {
        }

        #endregion Protected

        #region Public

        public virtual void Search()
        {
        }

        public virtual void ClearSearchFields()
        {
        }

        public virtual void ReturnSelectedEntity()
        {
        }

        public virtual void CloseForm()
        {
        }

        public virtual void DeleteSelectedEntity()
        {
        }

        public virtual void EditSelectedEntity()
        {
        }

        public virtual void CreateEntity()
        {
        }

        public virtual void BackToSearch()
        {
        }

        public virtual void SaveEntity()
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
