
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne
{
    public partial class CustomerInfrastructureAdministationSoftwaresControl : ManyToOneLevel1Control<CustomerInfrastructureAdministationSoftware>
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get
            {
                return (this.controller as CustomerInfrastructureAdministationSoftwaresControlController).CustomerInfrastructure;
            }
            set
            {
                (this.controller as CustomerInfrastructureAdministationSoftwaresControlController).CustomerInfrastructure = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureAdministationSoftwaresControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureAdministationSoftwaresControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureAdministationSoftwaresControlController).LoadControls();
        }

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureAdministationSoftwaresControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
