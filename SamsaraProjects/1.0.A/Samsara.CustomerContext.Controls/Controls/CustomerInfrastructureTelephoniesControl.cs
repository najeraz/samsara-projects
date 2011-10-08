using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureTelephoniesControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get
            {
                return (this.controller as CustomerInfrastructureTelephoniesControlController).CustomerInfrastructure;
            }
            set
            {
                (this.controller as CustomerInfrastructureTelephoniesControlController).CustomerInfrastructure = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureTelephoniesControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureTelephoniesControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureTelephoniesControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
