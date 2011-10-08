
using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureNetworkWifiAccessPointsControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureNetworkWifi CustomerInfrastructureNetworkWifi
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkWifiAccessPointsControlController)
                    .CustomerInfrastructureNetworkWifi;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkWifiAccessPointsControlController)
                    .CustomerInfrastructureNetworkWifi = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureNetworkWifiAccessPointsControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureNetworkWifiAccessPointsControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureNetworkWifiAccessPointsControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
