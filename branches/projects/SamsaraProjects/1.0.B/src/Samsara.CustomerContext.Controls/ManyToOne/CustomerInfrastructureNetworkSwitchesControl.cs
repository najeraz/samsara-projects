
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.ManyToOne
{
    public partial class CustomerInfrastructureNetworkSwitchesControl : ManyToOneLevel1Control<CustomerInfrastructureNetworkSwitch>
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkSwitchesControlController).CustomerInfrastructureNetwork;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkSwitchesControlController).CustomerInfrastructureNetwork = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureNetworkSwitchesControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureNetworkSwitchesControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureNetworkSwitchesControlController).LoadControls();
        }

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureNetworkSwitchesControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
