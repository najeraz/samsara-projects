
using System.Diagnostics;
using System.Windows.Forms;
using Samsara.Base.Forms.Controllers;
using Samsara.Base.Forms.Forms;
using Samsara.TIConsulting.Forms.Controllers;

namespace Samsara.TIConsulting.Forms.Forms
{
    public partial class ServerConsultingForm : GenericDocumentForm
    {
        #region Attributes

        private ServerConsultingFormController ctrlServerConsultingForm;

        #endregion Attributes

        #region Properties

        protected override SamsaraFormController Controller
        {
            set
            {
                base.Controller = value;
                this.ctrlServerConsultingForm = value as ServerConsultingFormController;
            }
        }

        #endregion Properties

        #region Constructor

        public ServerConsultingForm()
        {
            InitializeComponent();

            this.Controller = new ServerConsultingFormController(this);

            this.ctrlServerConsultingForm.InitializeFormControls();
        }

        #endregion Constructor

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
                    case "btnDetNextTab":
                        this.ctrlServerConsultingForm.NextTab();
                        break;
                    case "btnDetPreviousTab":
                        this.ctrlServerConsultingForm.PreviousTab();
                        break;
                    case "btnDetExportSummaryToExcel":
                        this.ctrlServerConsultingForm.ExportSummaryToExcel();
                        break;
                    case "btnDetCopySummary":
                        this.ctrlServerConsultingForm.SendSummaryToClipboard();
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
