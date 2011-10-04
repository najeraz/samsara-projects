using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureNetworkSiteRacksControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureNetworkSiteId
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkSiteRacksControlController).CustomerInfrastructureNetworkSiteId;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkSiteRacksControlController).CustomerInfrastructureNetworkSiteId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkSiteRack> CustomerInfrastructureNetworkSiteRacks
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkSiteRacksControlController).CustomerInfrastructureNetworkSiteRacks;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureNetworkSiteRacksControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureNetworkSiteRacksControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureNetworkSiteRacksControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
