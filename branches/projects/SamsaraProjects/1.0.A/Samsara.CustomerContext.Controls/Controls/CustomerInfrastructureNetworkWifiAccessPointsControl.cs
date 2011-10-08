
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
        public Nullable<int> CustomerInfrastructureNetworkWifiId
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkWifiAccessPointsControlController).CustomerInfrastructureNetworkWifiId;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkWifiAccessPointsControlController).CustomerInfrastructureNetworkWifiId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkWifiAccessPoint> CustomerInfrastructureNetworkWifiAccessPoints
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkWifiAccessPointsControlController).CustomerInfrastructureNetworkWifiAccessPoints;
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
