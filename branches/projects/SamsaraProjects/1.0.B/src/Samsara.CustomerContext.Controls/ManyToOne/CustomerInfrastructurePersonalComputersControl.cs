using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.ManyToOne
{
    public partial class CustomerInfrastructurePersonalComputersControl : ManyToOneLevel1Control<CustomerInfrastructurePersonalComputer>
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get
            {
                return (this.controller as CustomerInfrastructurePersonalComputersControlController).CustomerInfrastructure;
            }
            set
            {
                (this.controller as CustomerInfrastructurePersonalComputersControlController).CustomerInfrastructure = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructurePersonalComputersControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructurePersonalComputersControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructurePersonalComputersControlController).LoadControls();
        }

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructurePersonalComputersControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
