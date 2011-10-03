
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
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkRoutersControlController).CustomerInfrastructureNetworkId;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkRoutersControlController).CustomerInfrastructureNetworkId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkRouter> CustomerInfrastructureNetworkRouters
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkRoutersControlController).CustomerInfrastructureNetworkRouters;
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
