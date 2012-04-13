
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Choosers
{
    public partial class AccessPointBrandChooserControl 
        : SamsaraEntityChooserControl<AccessPointBrand, int, IAccessPointBrandService, IAccessPointBrandDao, AccessPointBrandParameters>
    {
        public AccessPointBrandChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.AccessPointBrandForm";
            InitializeComponent();
        }
    }
}
