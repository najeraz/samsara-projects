
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
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkFirewallsControlController).CustomerInfrastructureNetworkId;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkFirewallsControlController).CustomerInfrastructureNetworkId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkFirewall> CustomerInfrastructureNetworkFirewalls
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkFirewallsControlController).CustomerInfrastructureNetworkFirewalls;
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
