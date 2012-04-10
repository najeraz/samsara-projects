
using Samsara.AlleatoERP.Core.Entities;
using Samsara.AlleatoERP.Core.Parameters;
using Samsara.AlleatoERP.Dao.Interfaces;
using Samsara.AlleatoERP.Service.Interfaces;
using Samsara.Base.Controls.Controls;

namespace Samsara.AlleatoERP.Controls.Controls
{
    public partial class ProductFamilyChooserControl : SamsaraEntityChooserControl<ProductFamily, int, IProductFamilyService, IProductFamilyDao, ProductFamilyParameters>
    {
        public ProductFamilyChooserControl()
        {
            assemblyName = "Samsara.AlleatoERP.Forms.dll";
            assemblyFormClassName = "Samsara.AlleatoERP.Forms.Forms.ProductFamilyForm";
            InitializeComponent();
        }
    }
}
