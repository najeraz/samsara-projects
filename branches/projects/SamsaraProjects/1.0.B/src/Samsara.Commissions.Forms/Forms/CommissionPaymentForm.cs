
using Samsara.Base.Forms.Controllers;
using Samsara.Base.Forms.Forms;
using Samsara.Commissions.Forms.Controllers;

namespace Samsara.Commissions.Forms.Forms
{
    public partial class CommissionPaymentForm : GenericDocumentForm
    {
        #region Attributes

        private CommissionPaymentFormController ctrlCommissionPaymentForm;

        #endregion Attributes

        #region Properties

        protected override SamsaraFormController Controller
        {
            set
            {
                base.Controller = value;
                this.ctrlCommissionPaymentForm = value as CommissionPaymentFormController;
            }
        }

        #endregion Properties

        #region Constructor

        public CommissionPaymentForm()
        {
            InitializeComponent();

            this.Controller = new CommissionPaymentFormController(this);

            this.ctrlCommissionPaymentForm.InitializeFormControls();
        }

        #endregion Constructor
    }
}
