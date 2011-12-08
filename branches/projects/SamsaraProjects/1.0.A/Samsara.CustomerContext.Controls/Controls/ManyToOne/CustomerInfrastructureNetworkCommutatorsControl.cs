using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne
{
    public partial class CustomerInfrastructureNetworkCommutatorsControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkCommutatorsControlController).CustomerInfrastructureNetwork;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkCommutatorsControlController).CustomerInfrastructureNetwork = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureNetworkCommutatorsControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureNetworkCommutatorsControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureNetworkCommutatorsControlController).LoadControls();
        }

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureNetworkCommutatorsControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
