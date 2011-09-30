﻿using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureCCTVsControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureCCTVsControlController).CustomerInfrastructureId;
            }
            set
            {
                (this.controller as CustomerInfrastructureCCTVsControlController).CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureCCTV> CustomerInfrastructureCCTVs
        {
            get
            {
                return (this.controller as CustomerInfrastructureCCTVsControlController).CustomerInfrastructureCCTVs;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureCCTVsControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureCCTVsControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as CustomerInfrastructureCCTVsControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
