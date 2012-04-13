
using Samsara.Base.Controls.Controls;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Controls.Choosers
{
    public partial class TenderExchangeRateChooserControl : SamsaraEntityChooserControl<TenderExchangeRate, int, ITenderExchangeRateService, ITenderExchangeRateDao, TenderExchangeRateParameters>
    {
        public TenderExchangeRateChooserControl()
        {
            assemblyName = "Samsara.ProjectsAndTendering.Forms.dll";
            assemblyFormClassName = "Samsara.ProjectsAndTendering.Forms.Forms.TenderExchangeRateForm";
            InitializeComponent();
        }
    }
}
