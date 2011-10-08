
using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureNetworkFirewallsControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkFirewallsControlController).CustomerInfrastructureNetwork;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkFirewallsControlController).CustomerInfrastructureNetwork = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureNetworkFirewallsControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureNetworkFirewallsControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureNetworkFirewallsControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
