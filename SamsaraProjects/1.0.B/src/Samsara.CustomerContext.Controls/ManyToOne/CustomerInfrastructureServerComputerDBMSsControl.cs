using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.ManyToOne
{
    public partial class CustomerInfrastructureServerComputerDBMSsControl : ManyToOneLevel1Control<CustomerInfrastructureServerComputerDBMS>
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureServerComputer CustomerInfrastructureServerComputer
        {
            get
            {
                return (this.controller as CustomerInfrastructureServerComputerDBMSsControlController)
                    .CustomerInfrastructureServerComputer;
            }
            set
            {
                (this.controller as CustomerInfrastructureServerComputerDBMSsControlController)
                    .CustomerInfrastructureServerComputer = value;
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

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureServerComputerDBMSsControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
