using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne
{
    public partial class CustomerInfrastructureSecuritySoftwaresControl : ManyToOneLevel1Control<CustomerInfrastructureSecuritySoftware>
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get
            {
                return (this.controller as CustomerInfrastructureSecuritySoftwaresControlController).CustomerInfrastructure;
            }
            set
            {
                (this.controller as CustomerInfrastructureSecuritySoftwaresControlController).CustomerInfrastructure = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureSecuritySoftwaresControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureSecuritySoftwaresControlController(this);
        }

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureSecuritySoftwaresControlController).ClearControls();
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureSecuritySoftwaresControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
