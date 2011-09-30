using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureAdministationSoftwaresControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureAdministationSoftwaresControlController).CustomerInfrastructureId;
            }
            set
            {
                (this.controller as CustomerInfrastructureAdministationSoftwaresControlController).CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureAdministationSoftware> CustomerInfrastructureAdministationSoftwares
        {
            get
            {
                return (this.controller as CustomerInfrastructureAdministationSoftwaresControlController).CustomerInfrastructureAdministationSoftwares;
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

        public void LoadGrid()
        {
            (this.controller as CustomerInfrastructureAdministationSoftwaresControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
