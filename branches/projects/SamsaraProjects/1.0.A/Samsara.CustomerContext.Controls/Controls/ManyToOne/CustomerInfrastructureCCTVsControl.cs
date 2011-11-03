
using Samsara.Controls.Templates;
using Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne
{
    public partial class CustomerInfrastructureCCTVsControl : ManyToOneLevel1Control
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get
            {
                return (this.controller as CustomerInfrastructureCCTVsControlController).CustomerInfrastructure;
            }
            set
            {
                (this.controller as CustomerInfrastructureCCTVsControlController).CustomerInfrastructure = value;
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

        public void ClearControls()
        {
            (this.controller as CustomerInfrastructureCCTVsControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
