using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructurePersonalComputersControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructurePersonalComputersControlController).CustomerInfrastructureId;
            }
            set
            {
                (this.controller as CustomerInfrastructurePersonalComputersControlController).CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructurePersonalComputer> CustomerInfrastructurePersonalComputers
        {
            get
            {
                return (this.controller as CustomerInfrastructurePersonalComputersControlController).CustomerInfrastructurePersonalComputers;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructurePersonalComputersControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructurePersonalComputersControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructurePersonalComputersControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
