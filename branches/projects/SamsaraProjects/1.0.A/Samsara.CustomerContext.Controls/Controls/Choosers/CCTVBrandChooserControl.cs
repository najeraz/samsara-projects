
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls.Choosers
{
    public partial class CCTVBrandChooserControl : SamsaraEntityChooserControl<CCTVBrand, int, ICCTVBrandService, ICCTVBrandDao, CCTVBrandParameters>
    {
        public CCTVBrandChooserControl()
        {
            assemblyName = "Samsara.CustomerContext.Forms.dll";
            assemblyFormClassName = "Samsara.CustomerContext.Forms.Forms.CCTVBrandForm";
            InitializeComponent();
        }
    }
}
