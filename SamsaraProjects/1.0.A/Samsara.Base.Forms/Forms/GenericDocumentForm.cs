
using System.Diagnostics;
using System.Windows.Forms;
using Infragistics.Win;
using Samsara.Base.Forms.Controllers;

namespace Samsara.Base.Forms.Forms
{
    public partial class GenericDocumentForm : Form
    {
        #region Attributes

        protected GenericDocumentFormController controller;
         
        #endregion Attributes

        #region Properties

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

        [DebuggerStepThrough]
        private void btnClick(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                switch (btn.Name)
                {
                    case "btnSchSearch":
                        this.controller.Search();
                        break;
                    case "btnSchClear":
                        this.controller.ClearSearchFields();
                        break;
                    case "btnSchAccept":
                        this.controller.ReturnSelectedEntity();
                        break;
                    case "btnSchClose":
                        this.controller.CloseForm();
                        break;
                    case "btnSchDelete":
                        this.controller.DeleteEntityProcess();
                        break;
                    case "btnSchEdit":
                        this.controller.EditEntityProcess();
                        break;
                    case "btnSchCreate":
                        this.controller.CreateEntityProcess();
                        break;
                    case "btnDetSave":
                        this.controller.SaveEntityProcess();
                        break;
                    case "btnDetCancel":
                        this.controller.BackToSearch();
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
