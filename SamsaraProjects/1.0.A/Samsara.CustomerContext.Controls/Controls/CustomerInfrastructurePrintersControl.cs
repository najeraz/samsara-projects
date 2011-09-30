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
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructurePrintersControlController).CustomerInfrastructureId;
            }
            set
            {
                (this.controller as CustomerInfrastructurePrintersControlController).CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructurePrinter> CustomerInfrastructurePrinters
        {
            get
            {
                return (this.controller as CustomerInfrastructurePrintersControlController).CustomerInfrastructurePrinters;
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
