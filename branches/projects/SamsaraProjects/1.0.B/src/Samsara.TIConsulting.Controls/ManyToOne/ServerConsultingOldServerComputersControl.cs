
using Samsara.ProjectsAndTendering.Controls.ManyToOne.Templates;
using Samsara.TIConsulting.Controls.ManyToOne.Controllers;
using Samsara.TIConsulting.Core.Entities;

namespace Samsara.TIConsulting.Controls.ManyToOne
{
    public partial class ServerConsultingOldServerComputersControl : ServerConsultingOldServerComputerControlTemplate
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public ServerConsulting ServerConsulting
        {
            get
            {
                return (this.controller as ServerConsultingOldServerComputersControlController).ServerConsulting;
            }
            set
            {
                (this.controller as ServerConsultingOldServerComputersControlController).ServerConsulting = value;
            }
        }

        #endregion Properties

        #region Constructor

        public ServerConsultingOldServerComputersControl()
        {
            InitializeComponent();
            this.controller = new ServerConsultingOldServerComputersControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as ServerConsultingOldServerComputersControlController).LoadControls();
        }

        public void ClearControls()
        {
            (this.controller as ServerConsultingOldServerComputersControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
