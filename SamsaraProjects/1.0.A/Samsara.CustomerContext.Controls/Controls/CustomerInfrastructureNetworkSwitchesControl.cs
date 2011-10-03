
using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureNetworkSwitchesControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkSwitchesControlController).CustomerInfrastructureNetworkId;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkSwitchesControlController).CustomerInfrastructureNetworkId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkSwitch> CustomerInfrastructureNetworkSwitches
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkSwitchesControlController).CustomerInfrastructureNetworkSwitches;
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

        #endregion Public

        #endregion Methods
    }
}
