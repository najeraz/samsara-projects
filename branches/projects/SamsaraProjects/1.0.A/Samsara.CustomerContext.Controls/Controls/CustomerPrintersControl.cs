using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerPrintersControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerPrintersControlController).CustomerInfrastructureId;
            }
            set
            {
                (this.controller as CustomerPrintersControlController).CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructurePrinter> CustomerInfrastructurePrinters
        {
            get
            {
                return (this.controller as CustomerPrintersControlController).CustomerInfrastructurePrinters;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerPrintersControl()
        {
            InitializeComponent();
            this.controller = new CustomerPrintersControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadGrid()
        {
            (this.controller as CustomerPrintersControlController).LoadGrid();
        }

        #endregion Public

        #endregion Methods
    }
}
