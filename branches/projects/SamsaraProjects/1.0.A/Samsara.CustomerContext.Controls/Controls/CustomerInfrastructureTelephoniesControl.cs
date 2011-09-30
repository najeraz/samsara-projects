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
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureTelephoniesControlController).CustomerInfrastructureId;
            }
            set
            {
                (this.controller as CustomerInfrastructureTelephoniesControlController).CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureTelephonie> CustomerInfrastructureTelephonies
        {
            get
            {
                return (this.controller as CustomerInfrastructureTelephoniesControlController).CustomerInfrastructureTelephonies;
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

        public void LoadGrid()
        {
            (this.controller as CustomerInfrastructureTelephoniesControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
