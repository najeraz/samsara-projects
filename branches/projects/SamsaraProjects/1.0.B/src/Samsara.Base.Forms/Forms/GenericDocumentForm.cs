
using System.Diagnostics;
using System.Windows.Forms;
using Infragistics.Win;
using Samsara.Base.Forms.Controllers;

namespace Samsara.Base.Forms.Forms
{
    public partial class GenericDocumentForm : SamsaraForm
    {
        #region Attributes

        private GenericDocumentFormController ctrlGenericDocumentForm;

        #endregion Attributes

        #region Properties

        protected override SamsaraFormController Controller
        {
            set
            {
                base.Controller = value;
                this.ctrlGenericDocumentForm = value as GenericDocumentFormController;
            }
        }

        #endregion Properties

        #region Constructor

        public GenericDocumentForm()
        {
            InitializeComponent();
            this.grdPrincipal.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
        }

        #endregion Constructor

        #region Methods
        
        #endregion Methods

        #region Events

        [DebuggerStepThroughAttribute]
        private void btnClick(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                switch (btn.Name)
                {
                    case "btnSchSearch":
                        this.ctrlGenericDocumentForm.Search();
                        break;
                    case "btnSchClear":
                        this.ctrlGenericDocumentForm.ClearSearchFields();
                        break;
                    case "btnSchAccept":
                        this.ctrlGenericDocumentForm.ReturnSelectedEntity();
                        break;
                    case "btnSchClose":
                        this.ctrlGenericDocumentForm.CloseForm();
                        break;
                    case "btnSchDelete":
                        this.ctrlGenericDocumentForm.DeleteEntityProcess();
                        break;
                    case "btnSchEdit":
                        this.ctrlGenericDocumentForm.EditEntityProcess();
                        break;
                    case "btnSchCreate":
                        this.ctrlGenericDocumentForm.CreateEntityProcess();
                        break;
                    case "btnDetSave":
                        this.ctrlGenericDocumentForm.SaveEntityProcess();
                        break;
                    case "btnDetCancel":
                        this.ctrlGenericDocumentForm.BackToSearch();
                        break;
                    case "btnSchShowDetail":
                        this.ctrlGenericDocumentForm.ShowDetailProcess();
                        break;
                    case "btnDetBackToSearch":
                        this.ctrlGenericDocumentForm.BackToSearch();
                        break;
                    default:
                        break;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion Events
    }
}
