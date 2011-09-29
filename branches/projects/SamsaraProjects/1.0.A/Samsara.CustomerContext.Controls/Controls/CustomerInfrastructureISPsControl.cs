using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureISPsControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureISPsControlController).CustomerInfrastructureId;
            }
            set
            {
                (this.controller as CustomerInfrastructureISPsControlController).CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureISP> CustomerInfrastructureISPs
        {
            get
            {
                return (this.controller as CustomerInfrastructureISPsControlController).CustomerInfrastructureISPs;
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

        public void LoadGrid()
        {
            (this.controller as CustomerInfrastructureISPsControlController).LoadGrid();
        }

        #endregion Public

        #endregion Methods
    }
}
