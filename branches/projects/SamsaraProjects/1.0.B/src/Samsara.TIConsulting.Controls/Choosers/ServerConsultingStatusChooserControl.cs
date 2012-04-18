
using Samsara.Base.Controls.Controls;
using Samsara.TIConsulting.Core.Entities;
using Samsara.TIConsulting.Core.Parameters;
using Samsara.TIConsulting.Dao.Interfaces;
using Samsara.TIConsulting.Service.Interfaces;

namespace Samsara.TIConsulting.Controls.Choosers
{
    public partial class ServerConsultingStatusChooserControl : SamsaraEntityChooserControl<ServerConsultingStatus, int, IServerConsultingStatusService, IServerConsultingStatusDao, ServerConsultingStatusParameters>
    {
        public ServerConsultingStatusChooserControl()
        {
            assemblyName = "Samsara.TIConsulting.Forms.dll";
            assemblyFormClassName = "Samsara.TIConsulting.Forms.Forms.ServerConsultingStatusForm";
            InitializeComponent();
        }
    }
}
