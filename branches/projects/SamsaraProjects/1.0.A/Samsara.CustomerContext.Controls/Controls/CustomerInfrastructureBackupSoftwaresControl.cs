using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureBackupSoftwaresControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get
            {
                return (this.controller as CustomerInfrastructureBackupSoftwaresControlController).CustomerInfrastructure;
            }
            set
            {
                (this.controller as CustomerInfrastructureBackupSoftwaresControlController).CustomerInfrastructure = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureBackupSoftwaresControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureBackupSoftwaresControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureBackupSoftwaresControlController).LoadControls();
        }

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureBackupSoftwaresControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
