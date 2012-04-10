
using Samsara.Base.Controls.Controls;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Controls.Controls
{
    public partial class TenderSubstatusChooserControl : SamsaraEntityChooserControl<TenderSubstatus, int, ITenderSubstatusService, ITenderSubstatusDao, TenderSubstatusParameters>
    {
        public TenderSubstatusChooserControl()
        {
            assemblyName = "Samsara.ProjectsAndTendering.Forms.dll";
            assemblyFormClassName = "Samsara.ProjectsAndTendering.Forms.Forms.TenderSubstatusForm";
            InitializeComponent();
        }
    }
}
