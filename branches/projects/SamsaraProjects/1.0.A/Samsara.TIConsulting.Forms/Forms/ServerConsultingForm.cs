
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

        public ServerConsultingForm()
        {
            InitializeComponent();

            this.Controller = new ServerConsultingFormController(this);
        }
    }
}
