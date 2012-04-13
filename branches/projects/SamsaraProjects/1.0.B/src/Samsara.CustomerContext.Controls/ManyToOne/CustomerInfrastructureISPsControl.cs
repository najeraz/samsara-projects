﻿using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.ManyToOne
{
    public partial class CustomerInfrastructureISPsControl : ManyToOneLevel1Control<CustomerInfrastructureISP>
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get
            {
                return (this.controller as CustomerInfrastructureISPsControlController).CustomerInfrastructure;
            }
            set
            {
                (this.controller as CustomerInfrastructureISPsControlController).CustomerInfrastructure = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureISPsControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureISPsControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureISPsControlController).LoadControls();
        }

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureISPsControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
