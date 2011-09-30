using System;
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureBackupSoftwaresControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return (this.controller as CustomerInfrastructureBackupSoftwaresControlController).CustomerInfrastructureId;
            }
            set
            {
                (this.controller as CustomerInfrastructureBackupSoftwaresControlController).CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructureBackupSoftware> CustomerInfrastructureBackupSoftwares
        {
            get
            {
                return (this.controller as CustomerInfrastructureBackupSoftwaresControlController).CustomerInfrastructureBackupSoftwares;
            }
        }

        #endregion Properties

        #region Constructor

        public CustomerInfrastructureBackupSoftwaresControl()
        {
            InitializeComponent();
            this.controller = new CustomerInfrastructureBackupSoftwaresControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadGrid()
        {
            (this.controller as CustomerInfrastructureBackupSoftwaresControlController).LoadControls();
        }

        #endregion Public

        #endregion Methods
    }
}
