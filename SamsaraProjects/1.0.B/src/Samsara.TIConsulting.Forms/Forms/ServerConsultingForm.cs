
using System;
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

        private CustomerFormController ctrlServerConsultingForm;

        #endregion Attributes

        #region Properties

        protected override SamsaraFormController Controller
        {
            set
            {
                base.Controller = value;
                this.ctrlServerConsultingForm = value as CustomerFormController;
            }
        }

        #endregion Properties

        #region Constructor

        public ServerConsultingForm()
        {
            InitializeComponent();

            this.Controller = new CustomerFormController(this);

            this.ctrlServerConsultingForm.InitializeFormControls();
        }

        #endregion Constructor

        #region Events

        [DebuggerStepThroughAttribute]
        private void btnClick(object sender, EventArgs e)
        {
            Control control = sender as Control;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                switch (control.Name)
                {
                    case "ubtnDetNextTab":
                        this.ctrlServerConsultingForm.NextTab();
                        break;
                    case "ubtnDetPreviousTab":
                        this.ctrlServerConsultingForm.PreviousTab();
                        break;
                    case "btnDetExportSummaryToExcel":
                        this.ctrlServerConsultingForm.ExportSummaryToExcel();
                        break;
                    case "btnDetCopySummary":
                        this.ctrlServerConsultingForm.SendSummaryToClipboard();
                        break;
                    case "btnSchQuestions":
                        this.ctrlServerConsultingForm.ShowQuestions();
                        break;
                    case "btnDetExportQuestionsToExcel":
                        this.ctrlServerConsultingForm.ExportQuestionsToExcel();
                        break;
                    case "btnDetCopyQuestions":
                        this.ctrlServerConsultingForm.SendQuestionsToClipboard();
                        break;
                    case "btnDetCloseQuestions":
                        this.ctrlServerConsultingForm.BackToSearch();
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
