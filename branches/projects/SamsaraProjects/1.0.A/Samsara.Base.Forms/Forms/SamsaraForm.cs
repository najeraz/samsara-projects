
using System.Windows.Forms;
using Samsara.Base.Forms.Controllers;
using Samsara.Configuration.Code.Interfaces;
using Samsara.Configuration.Core.Entities;

namespace Samsara.Base.Forms.Forms
{
    public partial class SamsaraForm : Form, IConfigurableForm
    {
        #region Attributes

        private SamsaraFormController ctrlSamsaraForm;

        #endregion Attributes

        #region Properties

        public FormConfiguration FormConfiguration
        {
            get
            {
                return this.ctrlSamsaraForm.FormConfiguration;
            }
        }

        protected virtual SamsaraFormController Controller
        {
            set
            {
                this.ctrlSamsaraForm = value;
            }
        }

        #endregion Properties

        public SamsaraForm()
        {
            InitializeComponent();
        }
    }
}
