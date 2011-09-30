using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureServerComputersControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureServerComputersControlController).CustomerInfrastructureId;
            }
            set
            {
                (this.controller as CustomerInfrastructureServerComputersControlController).CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureServerComputer> CustomerInfrastructureServerComputers
        {
            get
            {
                return (this.controller as CustomerInfrastructureServerComputersControlController).CustomerInfrastructureServerComputers;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureServerComputersControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureServerComputersControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadGrid()
        {
            (this.controller as CustomerInfrastructureServerComputersControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
