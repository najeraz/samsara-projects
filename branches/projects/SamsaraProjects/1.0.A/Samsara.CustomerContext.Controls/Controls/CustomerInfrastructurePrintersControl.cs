using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructurePrintersControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get
            {
                return (this.controller as CustomerInfrastructurePrintersControlController).CustomerInfrastructure;
            }
            set
            {
                (this.controller as CustomerInfrastructurePrintersControlController).CustomerInfrastructure = value;
            }
        }
        
        #endregion Properties

        #region Constructor

        public CustomerInfrastructurePrintersControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructurePrintersControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructurePrintersControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
