
using Samsara.Base.Forms.Controllers;
using Samsara.Base.Forms.Forms;
using Samsara.Commissions.Forms.Controllers;

namespace Samsara.Commissions.Forms.Forms
{
    public partial class ServicesManagementForm : GenericDocumentForm
    {
        #region Attributes

        private ServicesManagementFormController ctrlServicesManagementForm;

        #endregion Attributes

        #region Properties

        protected override SamsaraFormController Controller
        {
            set
            {
                base.Controller = value;
                this.ctrlServicesManagementForm = value as ServicesManagementFormController;
            }
        }

        #endregion Properties

        public ServicesManagementForm()
        {
            InitializeComponent();

            this.Controller = new ServicesManagementFormController(this);

            this.ctrlServicesManagementForm.InitializeFormControls();
        }
    }
}
