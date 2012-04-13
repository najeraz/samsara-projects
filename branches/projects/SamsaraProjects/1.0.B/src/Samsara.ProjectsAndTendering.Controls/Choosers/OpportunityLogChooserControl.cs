
using Samsara.Base.Controls.Controls;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Controls.Choosers
{
    public partial class OpportunityLogChooserControl : SamsaraEntityChooserControl<OpportunityLog, int, IOpportunityLogService, IOpportunityLogDao, OpportunityLogParameters>
    {
        public OpportunityLogChooserControl()
        {
            assemblyName = "Samsara.ProjectsAndTendering.Forms.dll";
            assemblyFormClassName = "Samsara.ProjectsAndTendering.Forms.Forms.OpportunityLogForm";
            InitializeComponent();
        }
    }
}
