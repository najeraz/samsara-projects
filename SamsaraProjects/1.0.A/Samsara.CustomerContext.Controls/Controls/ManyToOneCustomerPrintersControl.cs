using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Samsara.Controls.Controls;
using Samsara.CustomerContext.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class ManyToOneCustomerPrintersControl : ManyToOneLevel1Control
    {

        #region Attributes

        internal ManyToOneCustomerPrintersControlController controller;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get
            {
                return this.controller.CustomerInfrastructureId;
            }
            set
            {
                this.controller.CustomerInfrastructureId = value;
            }
        }

        /// <summary>
        /// Entidades relacionadas
        /// </summary>
        public System.Collections.Generic.ISet<CustomerInfrastructurePrinter> CustomerInfrastructurePrinters
        {
            get
            {
                return this.controller.CustomerInfrastructurePrinters;
            }
        }

        #endregion Properties

        #region Constructor

        public ManyToOneCustomerPrintersControl()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadGrid()
        {
            this.controller.LoadGrid();
        }

        #endregion Public

        #endregion Methods
    }
}
