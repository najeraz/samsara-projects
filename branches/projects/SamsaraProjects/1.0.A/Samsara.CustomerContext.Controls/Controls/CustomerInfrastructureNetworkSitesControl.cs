using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureNetworkSitesControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkSitesControlController).CustomerInfrastructureNetworkId;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkSitesControlController).CustomerInfrastructureNetworkId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkSite> CustomerInfrastructureNetworkSites
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkSitesControlController).CustomerInfrastructureNetworkSites;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureNetworkSitesControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureNetworkSitesControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureNetworkSitesControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
