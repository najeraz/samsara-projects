using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne
{
    public partial class CustomerInfrastructureNetworkSiteRacksControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureNetworkSite CustomerInfrastructureNetworkSite
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkSiteRacksControlController)
                    .CustomerInfrastructureNetworkSite;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkSiteRacksControlController)
                    .CustomerInfrastructureNetworkSite = value;
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

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureNetworkSiteRacksControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
