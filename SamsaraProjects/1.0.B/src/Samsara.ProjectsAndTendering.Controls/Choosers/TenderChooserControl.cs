
using Samsara.Base.Controls.Controls;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Controls.Choosers
{
    public partial class TenderChooserControl : SamsaraEntityChooserControl<Tender, int, ITenderService, ITenderDao, TenderParameters>
    {
        public TenderChooserControl()
        {
            assemblyName = "Samsara.ProjectsAndTendering.Forms.dll";
            assemblyFormClassName = "Samsara.ProjectsAndTendering.Forms.Forms.TenderForm";
            InitializeComponent();
        }
    }
}
