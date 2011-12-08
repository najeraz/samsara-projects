
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne
{
    public partial class CustomerInfrastructureNetworkCablingsControl : ManyToOneLevel1Control<CustomerInfrastructureNetworkCabling>
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get
            {
                return (this.controller as CustomerInfrastructureNetworkCablingsControlController).CustomerInfrastructureNetwork;
            }
            set
            {
                (this.controller as CustomerInfrastructureNetworkCablingsControlController).CustomerInfrastructureNetwork = value;
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

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureNetworkCablingsControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
