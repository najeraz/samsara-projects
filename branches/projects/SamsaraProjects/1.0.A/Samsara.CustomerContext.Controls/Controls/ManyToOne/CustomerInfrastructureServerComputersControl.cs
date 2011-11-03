﻿using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne
{
    public partial class CustomerInfrastructureServerComputersControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get
            {
                return (this.controller as CustomerInfrastructureServerComputersControlController).CustomerInfrastructure;
            }
            set
            {
                (this.controller as CustomerInfrastructureServerComputersControlController).CustomerInfrastructure = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureServerComputersControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureServerComputersControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureServerComputersControlController).LoadControls();
        }

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureServerComputersControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
