﻿using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.ManyToOne
{
    public partial class CustomerInfrastructureUPSsControl : ManyToOneLevel1Control<CustomerInfrastructureUPS>
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get
            {
                return (this.controller as CustomerInfrastructureUPSsControlController).CustomerInfrastructure;
            }
            set
            {
                (this.controller as CustomerInfrastructureUPSsControlController).CustomerInfrastructure = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureUPSsControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureUPSsControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureUPSsControlController).LoadControls();
        }

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureUPSsControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
