
using Samsara.Base.Forms.Forms;
using Samsara.Commissions.Forms.Controllers;

namespace Samsara.Commissions.Forms.Forms
{
    public partial class ServicesManagementForm : GenericDocumentForm
    {
        ServicesManagementFormController ctrlServicesManagementForm;

        public ServicesManagementForm()
        {
            InitializeComponent();

            this.ctrlServicesManagementForm = new ServicesManagementFormController(this);
        }
    }
}
