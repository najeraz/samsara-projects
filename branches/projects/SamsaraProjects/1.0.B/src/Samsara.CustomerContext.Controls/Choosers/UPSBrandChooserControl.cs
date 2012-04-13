
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Choosers
{
    public partial class UPSBrandChooserControl : SamsaraEntityChooserControl<UPSBrand, int, IUPSBrandService, IUPSBrandDao, UPSBrandParameters>
    {
        public UPSBrandChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.UPSBrandForm";
            InitializeComponent();
        }
    }
}
