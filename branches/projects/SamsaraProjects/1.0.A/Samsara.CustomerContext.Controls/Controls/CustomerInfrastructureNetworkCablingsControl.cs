using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureNetworkCablingsControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkCablingsControlController).CustomerInfrastructureNetworkId;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkCablingsControlController).CustomerInfrastructureNetworkId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkCabling> CustomerInfrastructureNetworkCablings
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkCablingsControlController).CustomerInfrastructureNetworkCablings;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureNetworkCablingsControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureNetworkCablingsControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureNetworkCablingsControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
