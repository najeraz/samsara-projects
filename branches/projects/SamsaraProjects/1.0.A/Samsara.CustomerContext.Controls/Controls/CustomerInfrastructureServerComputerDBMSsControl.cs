using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureServerComputerDBMSsControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureServerComputerId
        {
            get
            {
                return (this.controller as CustomerInfrastructureServerComputerDBMSsControlController).CustomerInfrastructureServerComputerId;
            }
            set
            {
                (this.controller as CustomerInfrastructureServerComputerDBMSsControlController).CustomerInfrastructureServerComputerId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureServerComputerDBMS> CustomerInfrastructureServerComputerDBMSs
        {
            get
            {
                return (this.controller as CustomerInfrastructureServerComputerDBMSsControlController).CustomerInfrastructureServerComputerDBMSs;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureServerComputerDBMSsControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureServerComputerDBMSsControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureServerComputerDBMSsControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
