using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureSecuritySoftwaresControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureSecuritySoftwaresControlController).CustomerInfrastructureId;
            }
            set
            {
                (this.controller as CustomerInfrastructureSecuritySoftwaresControlController).CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureSecuritySoftware> CustomerInfrastructureSecuritySoftwares
        {
            get
            {
                return (this.controller as CustomerInfrastructureSecuritySoftwaresControlController).CustomerInfrastructureSecuritySoftwares;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureSecuritySoftwaresControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureSecuritySoftwaresControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureSecuritySoftwaresControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
