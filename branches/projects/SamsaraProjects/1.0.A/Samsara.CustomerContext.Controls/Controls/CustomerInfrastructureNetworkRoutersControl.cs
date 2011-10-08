
using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureNetworkRoutersControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkRoutersControlController).CustomerInfrastructureNetwork;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkRoutersControlController).CustomerInfrastructureNetwork = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureNetworkRoutersControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureNetworkRoutersControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureNetworkRoutersControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
