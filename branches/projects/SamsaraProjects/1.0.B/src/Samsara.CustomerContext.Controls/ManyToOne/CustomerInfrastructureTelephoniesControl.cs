using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.ManyToOne
{
    public partial class CustomerInfrastructureTelephoniesControl : ManyToOneLevel1Control<CustomerInfrastructureTelephony>
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get
            {
                return (this.controller as CustomerInfrastructureTelephoniesControlController).CustomerInfrastructure;
            }
            set
            {
                (this.controller as CustomerInfrastructureTelephoniesControlController).CustomerInfrastructure = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureTelephoniesControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureTelephoniesControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureTelephoniesControlController).LoadControls();
        }

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureTelephoniesControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
