
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Samsara.Base.Forms.Controllers;
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Forms.Controllers;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class CustomerForm : GenericDocumentForm
    {
        #region Attributes

        private CustomerFormController ctrlCustomerForm;

        #endregion Attributes

        #region Properties

        protected override SamsaraFormController Controller
        {
            set
            {
                base.Controller = value;
                this.ctrlCustomerForm = value as CustomerFormController;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerForm()
        {
            InitializeComponent();

            this.Controller = new CustomerFormController(this);

            this.ctrlCustomerForm.InitializeFormControls();
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
