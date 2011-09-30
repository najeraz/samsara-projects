using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureUPSsControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureUPSsControlController).CustomerInfrastructureId;
            }
            set
            {
                (this.controller as CustomerInfrastructureUPSsControlController).CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureUPS> CustomerInfrastructureUPSs
        {
            get
            {
                return (this.controller as CustomerInfrastructureUPSsControlController).CustomerInfrastructureUPSs;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureUPSsControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureUPSsControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadGrid()
        {
            (this.controller as CustomerInfrastructureUPSsControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
