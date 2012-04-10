
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls.Choosers
{
    public partial class SwitchBrandChooserControl : SamsaraEntityChooserControl<SwitchBrand, int, ISwitchBrandService, ISwitchBrandDao, SwitchBrandParameters>
    {
        public SwitchBrandChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.SwitchBrandForm";
            InitializeComponent();
        }
    }
}
