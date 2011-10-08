using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureNetworkCommutatorsControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkCommutatorsControlController).CustomerInfrastructureNetworkId;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkCommutatorsControlController).CustomerInfrastructureNetworkId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkCommutator> CustomerInfrastructureNetworkCommutators
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkCommutatorsControlController).CustomerInfrastructureNetworkCommutators;
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

        #endregion Public

        #endregion Methods
    }
}
