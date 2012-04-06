
using Samsara.Base.Controls.Controls;
using Samsara.TIConsulting.Controls.Controls.ManyToOne.Controllers;
using Samsara.TIConsulting.Core.Entities;

namespace Samsara.TIConsulting.Controls.Controls.ManyToOne
{
    public partial class ServerConsultingOldServerComputersControl : ManyToOneLevel1Control<ServerConsultingOldServerComputer>
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
