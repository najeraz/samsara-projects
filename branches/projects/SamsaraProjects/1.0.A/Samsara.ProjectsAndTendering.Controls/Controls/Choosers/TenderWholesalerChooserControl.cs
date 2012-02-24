
using Samsara.Base.Controls.Controls;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Controls.Controls.Choosers
{
    public partial class TenderWholesalerChooserControl : SamsaraEntityChooserControl<TenderWholesaler, int, ITenderWholesalerService, ITenderWholesalerDao, TenderWholesalerParameters>
    {
        public TenderWholesalerChooserControl()
        {
            assemblyName = "Samsara.ProjectsAndTendering.Forms.dll";
            assemblyFormClassName = "Samsara.ProjectsAndTendering.Forms.Forms.TenderWholesalerForm";
            InitializeComponent();
        }
    }
}
